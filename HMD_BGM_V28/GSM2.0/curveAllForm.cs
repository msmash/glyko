﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GSM2._0
{
    public partial class curveAllForm : Form
    {
        bool FirstShowForm = true;
        public class comm_list
        {
            public byte[] send_str;
            public double[] yValues = new double[12];
        }

        public curveAllForm()
        {
            InitializeComponent();
        }
        private void comMeterid_Click(object sender, EventArgs e)
        {
            FirstShowForm = false;
        }   
        private void getcomMeterid()
        {
            comMeterid.Items.Clear();
            comMeterid.DataSource = MainModule.GetMeteridWithUser();
            comMeterid.DisplayMember = "miduid";
            comMeterid.ValueMember = "mid";
            comMeterid.SelectedValue = alu_tp.main_1.MeterIDNo;  
        }
        private void comMeterid_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FirstShowForm == false)
                alu_tp.main_1.MeterIDNo = comMeterid.SelectedValue.ToString();
            if (alu_tp.main_1.MeterIDNo.ToLower() != "system.data.datarowview")
            {
                MainModule.SettingInitUserData();
                loadData();
            }
        }
        #region loadData
        private void loadData()
        {
            comm_list[] send_comm = new comm_list[6];
            Series[] DataSeries = new Series[6];
            Series[] DataSeries2 = new Series[6];
            Series[] series3 = new Series[6];
            Series[] series4 = new Series[6];
            DataPoint[] dataPoint1_1 = new DataPoint[6];
            DataPoint[] dataPoint2_1 = new DataPoint[6];
            DataPoint[] dataPoint3_1 = new DataPoint[6];
            DataPoint[] dataPoint4_1 = new DataPoint[6];
            DataPoint[] dataPoint5_1 = new DataPoint[6];
            DataPoint[] dataPoint6_1 = new DataPoint[6];
            DataPoint[] dataPoint7_1 = new DataPoint[6];
            DataPoint[] dataPoint8_1 = new DataPoint[6];
            StripLine[] s02 = new StripLine[6];
            Series BoxPlotSeries = new Series();

            Series[] BoxPlotSeries2 = new Series[6];
            //Series BoxPlotSeries3 = new Series();
            //Series BoxPlotSeries4 = new Series();
            //Series BoxPlotSeries5 = new Series();
            //Series BoxPlotSeries6 = new Series();
            //Series BoxPlotSeries7 = new Series();


            ChartArea[] chart2_3 = new ChartArea[6];
            
            ChartArea[] chart2_2 = new ChartArea[6];
            System.Data.DataView dv, dv1;

            chart1.ChartAreas.Clear();
            chart2.ChartAreas.Clear();
            chart3.ChartAreas.Clear();
            chart4.ChartAreas.Clear();
            chart5.ChartAreas.Clear();
            chart6.ChartAreas.Clear();
            chart7.ChartAreas.Clear();
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
            chart5.Series.Clear();
            chart6.Series.Clear();
            chart7.Series.Clear();

            //dv = MainModule.AccessDatabasesel("SELECT    format(gl.TestTime, 'YYYY-MM-DD') AS TestT, MAX(iif(isnull(a.GD0), 0,  CDBL(a.GD0))) AS Expr1, MAX(iif(isnull(a_1.GD1), 0, CDBL(a_1.GD1))) AS Expr2, " +
            //             " MAX(iif(isnull(a_2.GD2), 0, CDBL(a_2.GD2))) AS Expr3, MAX(iif(isnull(a_3.GD3),  0, CDBL(a_3.GD3))) AS Expr4, MAX(iif(isnull(a_4.GD4), 0, CDBL(a_4.GD4))) " +
            //            "  AS Expr5, MAX(iif(isnull(a_5.GD5), 0, CDBL(a_5.GD5))) AS Expr6,      MAX(iif(isnull(a_6.GD6), 0, CDBL(a_6.GD6))) AS Expr7, MAX(iif(isnull(a_7.GD7), " +
            //            "  0, CDBL(a_7.GD7))) AS Expr8, MAX(iif(isnull(a_8.GD8), 0, CDBL(a_8.GD8))) " +
            //            "  AS Expr9 FROM             (((((((((glucose gl LEFT OUTER JOIN " +
            //                "  (SELECT         GlucoseData AS GD0, format(TestTime, 'YYYY-MM-DD')   AS TT0    FROM           glucose gl_1 " +
            //                 "   WHERE          (TIME_IDX = 1)) a ON a.TT0 = format(gl.TestTime, 'YYYY-MM-DD'))   LEFT OUTER JOIN " +
            //                "  (SELECT         GlucoseData AS GD1, format(TestTime, 'YYYY-MM-DD')    AS TT1    FROM              glucose gl_2 " +
            //                  "  WHERE          (TIME_IDX = 2)) a_1 ON a_1.TT1 = format(gl.TestTime,      'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                 " (SELECT         GlucoseData AS GD2, format(TestTime, 'YYYY-MM-DD')      AS TT2        FROM              glucose gl_3 " +
            //                  "  WHERE          (TIME_IDX = 3)) a_2 ON a_2.TT2 = format(gl.TestTime,    'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                "  (SELECT         GlucoseData AS GD3, format(TestTime, 'YYYY-MM-DD')          AS TT3        FROM              glucose gl_4 " +
            //                 "   WHERE          (TIME_IDX = 4)) a_3 ON a_3.TT3 = format(gl.TestTime,          'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                 " (SELECT         GlucoseData AS GD4, format(TestTime, 'YYYY-MM-DD')         AS TT4       FROM              glucose gl_5 " +
            //                 "   WHERE          (TIME_IDX = 5)) a_4 ON a_4.TT4 = format(gl.TestTime,       'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                 " (SELECT         GlucoseData AS GD5, format(TestTime, 'YYYY-MM-DD')          AS TT5           FROM              glucose gl_6 " +
            //                  "  WHERE          (TIME_IDX = 6)) a_5 ON a_5.TT5 = format(gl.TestTime,         'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                 " (SELECT         GlucoseData AS GD6, format(TestTime, 'YYYY-MM-DD')     AS TT6       FROM              glucose gl_7 " +
            //                 "   WHERE          (TIME_IDX = 7)) a_6 ON a_6.TT6 = format(gl.TestTime,  'YYYY-MM-DD')) LEFT OUTER JOIN         (SELECT         GlucoseData AS GD7, format(TestTime, 'YYYY-MM-DD')  " +
            //                  "    AS TT7    FROM    glucose gl_8    WHERE  (TIME_IDX = 8)) a_7 ON a_7.TT7 = format(gl.TestTime,   'YYYY-MM-DD')) LEFT OUTER JOIN " +
            //                 " (SELECT         GlucoseData AS GD8, format(TestTime, 'YYYY-MM-DD')     AS TT8           FROM              glucose gl_9 " +
            //                  "  WHERE          (TIME_IDX = 9)) a_8 ON a_8.TT8 = format(gl.TestTime,    'YYYY-MM-DD')) " +
            //                  "  GROUP BY  format(gl.TestTime, 'YYYY-MM-DD') " +
            //                  "  ORDER BY  format(gl.TestTime, 'YYYY-MM-DD') DESC ");





            dv = MainModule.SetGlucoseToTimeSet();
            dv1 = MainModule.AccessDatabasesel("SELECT  format(TestTime, 'YYYY-MM-DD') AS TestT, GlucoseData,m_Event,time_IDX    FROM  glucose where  MeterID='" + alu_tp.main_1.MeterIDNo + "' ORDER BY TestTime DESC");




            int TTT1 = dv1.Count;
            int[] count1 = new int[6];
            for (int ii = 0; ii < 6; ii++)
            {
                DataSeries[ii] = new Series();
                DataSeries2[ii] = new Series();
                series3[ii] = new Series();
                series4[ii] = new Series();
                s02[ii] = new StripLine();
                send_comm[ii] = new comm_list();
                count1[ii] = 0;
                BoxPlotSeries2[ii] = new Series();
                chart2_3[ii] = new ChartArea();
                chart2_2[ii] = new ChartArea();
            }
            for (int jj = 0; jj < dv.Count; jj++)
            {

                for (int ii = 0; ii < 6; ii++)
                {

                    string eestr = "Expr" + (ii + 1);
                    //   send_comm[ii].yValues[count1[ii]] = rand.Next(45, 95);

                    if (Convert.ToInt16(dv[jj].Row[eestr]) == 0)
                    {
                    }
                    else
                    {

                        count1[ii]++;
                    }
                    dv1.RowFilter = "TestT= '" + Convert.ToString(dv[jj].Row[0]) + "' and time_IDX='" + Convert.ToString(ii + 1) + "' and GlucoseData <> '" + Convert.ToInt16(dv[jj].Row[eestr]) + "' and GlucoseData <> '0'";
                    if (dv1.Count > 0)
                    {
                        for (int t1 = 0; t1 < dv1.Count; t1++)
                        {
                            count1[ii]++;
                        }
                    }

                }
            }
            for (int jj = 0; jj < 6; jj++)
            {
                send_comm[jj].yValues = new double[count1[jj]];
            }
            int[] count2 = new int[6];
            for (int jj = 0; jj < dv.Count; jj++)
            {

                for (int ii = 0; ii < 6; ii++)
                {
                    string eestr = "Expr" + (ii + 1);
                    //   send_comm[ii].yValues[count1[ii]] = rand.Next(45, 95);
                    if (Convert.ToInt16(dv[jj].Row[eestr]) == 0)
                    {
                    }
                    else
                    {
                        send_comm[ii].yValues[count2[ii]] = Convert.ToInt16(dv[jj].Row[eestr]);
                        count2[ii]++;
                    }

                    //  send_comm[jj].yValues[ii] = rand.Next(45, 95);

                    dv1.RowFilter = "TestT= '" + Convert.ToString(dv[jj].Row[0]) + "' and time_IDX='" + Convert.ToString(ii + 1) + "' and GlucoseData <> '" + Convert.ToInt16(dv[jj].Row[eestr]) + "' and GlucoseData <> '0'";
                    if (dv1.Count > 0)
                    {
                        for (int t1 = 0; t1 < dv1.Count; t1++)
                        {
                            send_comm[ii].yValues[count2[ii]] = Convert.ToUInt16(dv1[t1].Row["GlucoseData"]);
                            count2[ii]++;
                        }
                    }

                }
            }


            ChartArea ChartArea3 = new ChartArea();
            ChartArea ChartArea2 = new ChartArea();
            //ChartArea chart2_3 = new ChartArea();
            //ChartArea chart2_2 = new ChartArea();



       
            //Add the charting areas to the chart

            chart1.ChartAreas.Add(ChartArea2);
            chart1.ChartAreas.Add(ChartArea3);


            ChartArea2.Name = "Data Chart Area";
            ChartArea3.Name = "Box Plot Area";
            //ChartArea3.AlignWithChartArea = "Data Chart Area"
            ChartArea2.Position.X = 2;
            ChartArea2.Position.Y = 70;

            //     ChartArea2.AxisX.ScaleBreakStyle.Spacing = .5;
            //    ChartArea3.AxisX.ScaleBreakStyle.StartFromZero = StartFromZero.No
            //ChartArea2.AxisX.Minimum = 0.5;
            //         ChartArea2.AxisX.Maximum = 7;
            ChartArea3.Position.X = 2;
            ChartArea3.Position.Y = 3;

            //    ChartArea2.Position.Height = 92f;
            //      ChartArea2.Position.Width = 90f;
            //  ChartArea3.Position.Height = 92f;
            //   ChartArea3.Position.Width = 90f;
            //     ChartArea2.BackImageTransparentColor = System.Drawing.Color.White;
            ChartArea3.Position.Height = 92f;
            ChartArea3.Position.Width = 90f;
            ChartArea3.AxisX.ScaleBreakStyle.Spacing = .5;
            //    ChartArea3.AxisX.ScaleBreakStyle.StartFromZero = StartFromZero.No
            ChartArea3.AxisX.Minimum = 0.5;
            ChartArea3.AxisX.Maximum = 7;


            //  BackGradientStyle = "VerticalCenter"
            //   ChartArea3.ShadowColor = Drawing.Color.Cyan
            //  ChartArea3.BackSecondaryColor = Drawing.Color.FromArgb(128, 255, 255)
            //  ChartArea3.BorderColor = Drawing.Color.Black

            for (int ii = 0; ii < 6; ii++)
            {

                if (ii == 0) { chart2.ChartAreas.Add(chart2_2[ii]); chart2.ChartAreas.Add(chart2_3[ii]); }
                else if (ii == 1) { chart3.ChartAreas.Add(chart2_2[ii]); chart3.ChartAreas.Add(chart2_3[ii]); }
                else if (ii == 2) { chart4.ChartAreas.Add(chart2_2[ii]); chart4.ChartAreas.Add(chart2_3[ii]); }
                else if (ii == 3) { chart5.ChartAreas.Add(chart2_2[ii]); chart5.ChartAreas.Add(chart2_3[ii]); }
                else if (ii == 4) { chart6.ChartAreas.Add(chart2_2[ii]); chart6.ChartAreas.Add(chart2_3[ii]); }
                else if (ii == 5) { chart7.ChartAreas.Add(chart2_2[ii]); chart7.ChartAreas.Add(chart2_3[ii]); }

                //  chart2.ChartAreas.Add(chart2_2);
                //   chart2.ChartAreas.Add(chart2_3);

                chart2_2[ii].Name = "Data Chart Area" + (ii + 1);
                chart2_3[ii].Name = "Box Plot Area" + (ii + 1);
                chart2_2[ii].Position.X = 2;
                chart2_2[ii].Position.Y = 4;
                chart2_3[ii].Position.X = 60;
                chart2_3[ii].Position.Y = 4;
                chart2_2[ii].Position.Height = 92f;
                chart2_2[ii].Position.Width = 55f;
                chart2_3[ii].Position.Height = 92f;
                chart2_3[ii].Position.Width = 30f;
                chart2_3[ii].AxisX.ScaleBreakStyle.Spacing = .5;
                chart2_3[ii].AxisX.Minimum = 0.5;
                chart2_3[ii].AxisX.Maximum = 1.5;
                chart2_2[ii].AxisY.Maximum = 600;
                chart2_3[ii].AxisY.Maximum = 600;

            }




            for (int jj = 0; jj < 6; jj++)
            {
                series3[jj].Name = "BoxPlotLabels" + jj;
                series3[jj].ChartArea = "Box Plot Area";
                series3[jj].ChartType = SeriesChartType.Point;
                series3[jj].CustomProperties = "LabelStyle=Right";
                series3[jj].Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
                series3[jj].Legend = "Default";

                series4[jj].Name = "BoxPlotLabel" + jj;
                series4[jj].ChartArea = "Box Plot Area" + (jj + 1);
                series4[jj].ChartType = SeriesChartType.Point;
                series4[jj].CustomProperties = "LabelStyle=Right";
                series4[jj].Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
                series4[jj].Legend = "Default";



            }
            for (int jj = 0; jj < 6; jj++)
            {
                DataPoint dataPoint1 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint2 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint3 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint4 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint5 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint6 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint7 = new DataPoint(1 + jj, 0);
                DataPoint dataPoint8 = new DataPoint(1 + jj, 0);
                dataPoint1.Color = System.Drawing.Color.Transparent;
                dataPoint2.Color = System.Drawing.Color.Transparent;
                dataPoint3.Color = System.Drawing.Color.Transparent;
                dataPoint4.Color = System.Drawing.Color.Transparent;
                dataPoint5.Color = System.Drawing.Color.Transparent;
                dataPoint6.Color = System.Drawing.Color.Transparent;
                dataPoint7.Color = System.Drawing.Color.Transparent;
                dataPoint8.Color = System.Drawing.Color.Transparent;

                series3[jj].Points.Add(dataPoint1);
                series3[jj].Points.Add(dataPoint2);
                series3[jj].Points.Add(dataPoint3);
                series3[jj].Points.Add(dataPoint4);
                series3[jj].Points.Add(dataPoint5);
                series3[jj].Points.Add(dataPoint6);
                series3[jj].Points.Add(dataPoint7);
                series3[jj].Points.Add(dataPoint8);
                series3[jj].SmartLabelStyle.Enabled = false;


                dataPoint1_1[jj] = new DataPoint(1.1, 0);//位置1,0
                dataPoint2_1[jj] = new DataPoint(1.1, 0);
                dataPoint3_1[jj] = new DataPoint(1.1, 0);
                dataPoint4_1[jj] = new DataPoint(1.1, 0);
                dataPoint5_1[jj] = new DataPoint(1.1, 0);
                dataPoint6_1[jj] = new DataPoint(1.1, 0);
                dataPoint7_1[jj] = new DataPoint(1.1, 0);
                dataPoint8_1[jj] = new DataPoint(1.1, 0);

                dataPoint1_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint2_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint3_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint4_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint5_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint6_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint7_1[jj].Color = System.Drawing.Color.Transparent;
                dataPoint8_1[jj].Color = System.Drawing.Color.Transparent;

                series4[jj].Points.Add(dataPoint1_1[jj]);
                series4[jj].Points.Add(dataPoint2_1[jj]);
                series4[jj].Points.Add(dataPoint3_1[jj]);
                series4[jj].Points.Add(dataPoint4_1[jj]);
                series4[jj].Points.Add(dataPoint5_1[jj]);
                series4[jj].Points.Add(dataPoint6_1[jj]);
                series4[jj].Points.Add(dataPoint7_1[jj]);
                series4[jj].Points.Add(dataPoint8_1[jj]);
                series4[jj].SmartLabelStyle.Enabled = false;


            }

            for (int jj = 0; jj < 6; jj++)
            {
                DataSeries[jj].Name = "DataSeries" + jj;
                DataSeries[jj].ChartType = SeriesChartType.Point;
                DataSeries[jj].ChartArea = "Data Chart Area";
                //   DataSeries[jj].ChartArea = "Box Plot Area";
                ////   DataSeries[jj].IsValueShownAsLabel = false;
                //  DataSeries[jj].IsVisibleInLegend = false;
                DataSeries2[jj].Name = "DataSeries" + jj;
                DataSeries2[jj].ChartType = SeriesChartType.Point;
                DataSeries2[jj].ChartArea = "Data Chart Area" + (jj + 1);
            }
            BoxPlotSeries.Name = "BoxPlotSeries";
            BoxPlotSeries.ChartType = SeriesChartType.BoxPlot;
            BoxPlotSeries.ChartArea = "Box Plot Area";
            //   BoxPlotSeries.IsValueShownAsLabel = true;
            BoxPlotSeries.IsVisibleInLegend = true;
            BoxPlotSeries.BackGradientStyle = GradientStyle.VerticalCenter;
            BoxPlotSeries.Color = System.Drawing.Color.Cyan;
            BoxPlotSeries.BackSecondaryColor = System.Drawing.Color.FromArgb(128, 255, 255);
            BoxPlotSeries.BorderColor = System.Drawing.Color.Black;

            
            chart1.Series.Add(BoxPlotSeries);

            // Add data to Box Plot Source series.
            string datastr = "";
            for (int jj = 0; jj < 6; jj++)
            {
                chart1.Series.Add(series3[jj]);
                chart1.Series.Add(DataSeries[jj]);
                chart1.Series[DataSeries[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                if (jj > 0) { datastr = datastr + ";" + DataSeries[jj].Name; } else { datastr = DataSeries[jj].Name; }
            }
            chart1.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart1.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Set whiskers 15th percentile.
            chart1.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart1.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart1.Series["BoxPlotSeries"]["PointWidth"] = "0.25";
            chart1.Series["BoxPlotSeries"].XValueMember = "day of week";

            //    ChartArea3.AxisX.CustomLabels.Add(0, 2, "Before breakfast");
            //  ChartArea3.AxisX.CustomLabels.Add(0, 4, "After breakfast");
            //   ChartArea3.AxisX.CustomLabels.Add(0, 6, "Before lunch");
            //   ChartArea3.AxisX.CustomLabels.Add(0, 8, "After lunch");
            //   ChartArea3.AxisX.CustomLabels.Add(0, 10, "Before dinner");
            //   ChartArea3.AxisX.CustomLabels.Add(0, 12, "After dinner");


            ChartArea3.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            ChartArea3.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            //  alu_tp.main_1.TargetMaxOption = int.Parse(alu_tp.main_1.DataTargetMax[i]);
            //  alu_tp.main_1.TargetMinOption = int.Parse(alu_tp.main_1.DataTargetMin[i]);
            //   alu_tp.main_1.TargetMaxOptionp = int.Parse(alu_tp.main_1.DataTargetMaxp[i]);
            //   alu_tp.main_1.TargetMinOptionp = int.Parse(alu_tp.main_1.DataTargetMinp[i]);


            StripLine s01;

            if (alu_tp.main_1.TargetMaxOptionp.ToString().Length > 0 || alu_tp.main_1.TargetMinOptionp.ToString().Length > 0)
            {
                s01 = new StripLine();
                s01.BackColor = Color.FromArgb(248, 199, 213);
                s01.IntervalOffset = 0;

                s01.StripWidth = 600;
                ChartArea3.AxisY.StripLines.Add(s01);

                for (int jj = 0; jj < 6; jj++)
                {
                    s01 = new StripLine();
                    s01.BackColor = Color.FromArgb(248, 199, 213);
                    s01.IntervalOffset = 0;
                    s01.StripWidth = 600;

                    s02[jj] = new StripLine();
                    s02[jj].BackColor = Color.FromArgb(248, 199, 213);
                    s02[jj].IntervalOffset = 0;
                    s02[jj].StripWidth = 600;

                    chart2_2[jj].AxisY.StripLines.Add(s02[jj]);
                    chart2_3[jj].AxisY.StripLines.Add(s01);
                }


                s01 = new StripLine();
                s01.BackColor = Color.FromArgb(245, 250, 189);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOptionp);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOptionp) - s01.IntervalOffset;
                ChartArea3.AxisY.StripLines.Add(s01);

                for (int jj = 0; jj < 6; jj++)
                {
                    s01 = new StripLine();
                    s01.BackColor = Color.FromArgb(245, 250, 189);
                    s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOptionp);
                    s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOptionp) - s01.IntervalOffset;

                    s02[jj] = new StripLine();
                    s02[jj].BackColor = Color.FromArgb(245, 250, 189);
                    s02[jj].IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOptionp);

                    s02[jj].StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOptionp) - s02[jj].IntervalOffset;
                    chart2_2[jj].AxisY.StripLines.Add(s02[jj]);
                    chart2_3[jj].AxisY.StripLines.Add(s01);
                }
            }

            if (alu_tp.main_1.TargetMaxOption.ToString().Length > 0 || alu_tp.main_1.TargetMinOption.ToString().Length > 0)
            {

                s01 = new StripLine();

                s01.BackColor = Color.FromArgb(190, 251, 210);
                s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOption);

                s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOption) - s01.IntervalOffset;
                ChartArea3.AxisY.StripLines.Add(s01);
                for (int jj = 0; jj < 6; jj++)
                {
                    s01 = new StripLine();

                    s01.BackColor = Color.FromArgb(190, 251, 210);
                    s01.IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOption);
                    s01.StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOption) - s01.IntervalOffset;

                    s02[jj] = new StripLine();
                    s02[jj].BackColor = Color.FromArgb(190, 251, 210);
                    s02[jj].IntervalOffset = Convert.ToInt16(alu_tp.main_1.TargetMinOption);

                    s02[jj].StripWidth = Convert.ToInt16(alu_tp.main_1.TargetMaxOption) - s02[jj].IntervalOffset;
                    chart2_2[jj].AxisY.StripLines.Add(s02[jj]);
                    chart2_3[jj].AxisY.StripLines.Add(s01);
                }
            }
            for (int jj = 0; jj < 6; jj++)
            {
                chart1.Series[DataSeries[jj].Name].Enabled = false;
            }

            ////////////////////////
            for (int jj = 0; jj < 6; jj++)
            {
                BoxPlotSeries2[jj].Name = "BoxPlotSeries";
                BoxPlotSeries2[jj].ChartType = SeriesChartType.BoxPlot;
                BoxPlotSeries2[jj].ChartArea = "Box Plot Area" + (jj + 1);
                //   BoxPlotSeries.IsValueShownAsLabel = true;
                BoxPlotSeries2[jj].IsVisibleInLegend = true;
                BoxPlotSeries2[jj].BackGradientStyle = GradientStyle.VerticalCenter;
                BoxPlotSeries2[jj].Color = System.Drawing.Color.Cyan;
                BoxPlotSeries2[jj].BackSecondaryColor = System.Drawing.Color.FromArgb(128, 255, 255);
                BoxPlotSeries2[jj].BorderColor = System.Drawing.Color.Black;
                if (jj == 0) chart2.Series.Add(BoxPlotSeries2[jj]);
                else if (jj == 1) chart3.Series.Add(BoxPlotSeries2[jj]);
                else if (jj == 2) chart4.Series.Add(BoxPlotSeries2[jj]);
                else if (jj == 3) chart5.Series.Add(BoxPlotSeries2[jj]);
                else if (jj == 4) chart6.Series.Add(BoxPlotSeries2[jj]);
                else if (jj == 5) chart7.Series.Add(BoxPlotSeries2[jj]);

            }

            datastr = "";
            for (int jj = 0; jj < 1; jj++)
            {
                chart2.Series.Add(series4[jj]);
                chart2.Series.Add(DataSeries2[jj]);
                chart2.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart2.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart2.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Set whiskers 15th percentile.
            chart2.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart2.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart2.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart2.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart2.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart2.Series["BoxPlotSeries"].XValueMember = "day of week";


            datastr = "";
            for (int jj = 1; jj < 2; jj++)
            {
                chart3.Series.Add(series4[jj]);
                chart3.Series.Add(DataSeries2[jj]);
                chart3.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart3.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart3.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Se3t whiskers 15th percentile.
            chart3.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart3.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart3.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart3.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart3.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart3.Series["BoxPlotSeries"].XValueMember = "day of week";


            datastr = "";
            for (int jj = 2; jj < 3; jj++)
            {
                chart4.Series.Add(series4[jj]);
                chart4.Series.Add(DataSeries2[jj]);
                chart4.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart4.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart4.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Se3t whiskers 15th percentile.
            chart4.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart4.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart4.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart4.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart4.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart4.Series["BoxPlotSeries"].XValueMember = "day of week";

            datastr = "";
            for (int jj = 3; jj < 4; jj++)
            {
                chart5.Series.Add(series4[jj]);
                chart5.Series.Add(DataSeries2[jj]);
                chart5.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart5.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart5.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Se3t whiskers 15th percentile.
            chart5.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart5.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart5.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart5.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart5.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart5.Series["BoxPlotSeries"].XValueMember = "day of week";

            datastr = "";
            for (int jj = 4; jj < 5; jj++)
            {
                chart6.Series.Add(series4[jj]);
                chart6.Series.Add(DataSeries2[jj]);
                chart6.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart6.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart6.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Se3t whiskers 15th percentile.
            chart6.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart6.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart6.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart6.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart6.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart6.Series["BoxPlotSeries"].XValueMember = "day of week";

            datastr = "";
            for (int jj = 5; jj < 6; jj++)
            {
                chart7.Series.Add(series4[jj]);
                chart7.Series.Add(DataSeries2[jj]);
                chart7.Series[DataSeries2[jj].Name].Points.DataBindY(send_comm[jj].yValues);
                datastr = DataSeries2[jj].Name;
            }
            chart7.Series["BoxPlotSeries"]["BoxPlotWhiskerPercentile"] = "0";
            chart7.Series["BoxPlotSeries"]["BoxPlotSeries"] = datastr;
            // Se7t whiskers 15th percentile.
            chart7.Series["BoxPlotSeries"]["BoxPlotWhiskerPerc entile"] = "10";
            // Show/Hide Average line.
            chart7.Series["BoxPlotSeries"]["BoxPlotShowAverage "] = "true";
            // Show/Hide Median line.
            chart7.Series["BoxPlotSeries"]["BoxPlotShowMedian"] = "true";

            // Show/Hide Unusual points.
            chart7.Series["BoxPlotSeries"]["BoxPlotShowUnusual Values"] = "true";
            //  chart1.Series("BoxPlotSeries")("PointWidth") = "0.25"
            chart7.Series["BoxPlotSeries"]["PointWidth"] = "0.15";
            chart7.Series["BoxPlotSeries"].XValueMember = "day of week";


            chart2_3[0].AxisX.CustomLabels.Add(0, 2, "Before breakfast");
            chart2_3[1].AxisX.CustomLabels.Add(0, 2, "After breakfast");
            chart2_3[2].AxisX.CustomLabels.Add(0, 2, "Before lunch");
            chart2_3[3].AxisX.CustomLabels.Add(0, 2, "After lunch");
            chart2_3[4].AxisX.CustomLabels.Add(0, 2, "Before dinner");
            chart2_3[5].AxisX.CustomLabels.Add(0, 2, "After dinner");

            ////////////////////////////
        }
        #endregion
        #region Init Control
        private void InitControls()
        {
            this.Text = alu_tp.main_1.rm_txt.GetString("Menu_ALLGraph");
            label3.Text = alu_tp.main_1.rm_txt.GetString("UserID");
        }
        #endregion

        private void curveAllForm_Load(object sender, EventArgs e)
        {
            InitControls();
            getcomMeterid();
            //comMeterid_SelectedValueChanged(null, null);            
        }
        protected void chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {

            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area")
            {

                for (int jj = 0; jj < 6; jj++)
                {
                    string bxname = "BoxPlotLabels" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart1.Series[bxname].Points[0].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[0];
                    chart1.Series[bxname].Points[1].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[1];
                    chart1.Series[bxname].Points[2].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[2];
                    chart1.Series[bxname].Points[3].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[3];
                    chart1.Series[bxname].Points[4].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[4];
                    chart1.Series[bxname].Points[5].YValues[0] = chart1.Series["BoxPlotSeries"].Points[jj].YValues[5];


                    chart1.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[0]);
                    chart1.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[1]);
                    chart1.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[2]);
                    chart1.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[3]);
                    chart1.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[4]);
                    chart1.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart1.Series["BoxPlotSeries"].Points[jj].YValues[5]);


                }

            }



        }

        protected void chart2_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area1")
            {

                for (int jj = 0; jj < 1; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart2.Series[bxname].Points[0].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart2.Series[bxname].Points[1].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart2.Series[bxname].Points[2].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart2.Series[bxname].Points[3].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart2.Series[bxname].Points[4].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart2.Series[bxname].Points[5].YValues[0] = chart2.Series["BoxPlotSeries"].Points[0].YValues[5];


                    chart2.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart2.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart2.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart2.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart2.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart2.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart2.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }
        }
        protected void chart3_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area2")
            {

                for (int jj = 1; jj < 2; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart3.Series[bxname].Points[0].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart3.Series[bxname].Points[1].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart3.Series[bxname].Points[2].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart3.Series[bxname].Points[3].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart3.Series[bxname].Points[4].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart3.Series[bxname].Points[5].YValues[0] = chart3.Series["BoxPlotSeries"].Points[0].YValues[5];

                    chart3.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart3.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart3.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart3.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart3.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart3.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart3.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }

        }

        protected void chart4_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area3")
            {

                for (int jj = 2; jj < 3; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart4.Series[bxname].Points[0].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart4.Series[bxname].Points[1].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart4.Series[bxname].Points[2].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart4.Series[bxname].Points[3].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart4.Series[bxname].Points[4].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart4.Series[bxname].Points[5].YValues[0] = chart4.Series["BoxPlotSeries"].Points[0].YValues[5];

                    chart4.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart4.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart4.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart4.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart4.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart4.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart4.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }
        }
        protected void chart5_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area4")
            {

                for (int jj = 3; jj < 4; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart5.Series[bxname].Points[0].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart5.Series[bxname].Points[1].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart5.Series[bxname].Points[2].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart5.Series[bxname].Points[3].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart5.Series[bxname].Points[4].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart5.Series[bxname].Points[5].YValues[0] = chart5.Series["BoxPlotSeries"].Points[0].YValues[5];

                    chart5.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart5.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart5.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart5.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart5.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart5.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart5.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }
        }
        protected void chart6_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area5")
            {

                for (int jj = 4; jj < 5; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart6.Series[bxname].Points[0].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart6.Series[bxname].Points[1].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart6.Series[bxname].Points[2].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart6.Series[bxname].Points[3].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart6.Series[bxname].Points[4].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart6.Series[bxname].Points[5].YValues[0] = chart6.Series["BoxPlotSeries"].Points[0].YValues[5];

                    chart6.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart6.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart6.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart6.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart6.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart6.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart6.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }
        }
        protected void chart7_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement.ToString() == "ChartArea-Data Chart Area6")
            {

                for (int jj = 5; jj < 6; jj++)
                {
                    string bxname = "BoxPlotLabel" + jj;
                    // Position point chart type series on the points of the box plot to display labels        
                    chart7.Series[bxname].Points[0].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[0];
                    chart7.Series[bxname].Points[1].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[1];
                    chart7.Series[bxname].Points[2].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[2];
                    chart7.Series[bxname].Points[3].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[3];
                    chart7.Series[bxname].Points[4].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[4];
                    chart7.Series[bxname].Points[5].YValues[0] = chart7.Series["BoxPlotSeries"].Points[0].YValues[5];

                    chart7.Series[bxname].Points[0].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[0]);
                    chart7.Series[bxname].Points[1].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[1]);
                    chart7.Series[bxname].Points[2].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[2]);
                    chart7.Series[bxname].Points[3].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[3]);
                    chart7.Series[bxname].Points[4].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[4]);
                    chart7.Series[bxname].Points[5].Label = string.Format("{0:F1}", chart7.Series["BoxPlotSeries"].Points[0].YValues[5]);

                }

            }
        }

    
    }
}