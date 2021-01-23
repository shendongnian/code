         public void DrawMembersvisits(Chart targetchartcontrol, DateTime startdate, DateTime enddate)
        {
            chart1 = targetchartcontrol;
            Series series = null;
            Title title;
            string area = null;
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            DataTable membervisits = null;
            area = "Visits";
            chart1.ChartAreas.Add(area);
            series = chart1.Series.Add(area);
            series.ChartArea = area;
            title = chart1.Titles.Add("Member Visits");
                      
           
           title.Alignment = ContentAlignment.MiddleCenter;
           title.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
           
            title.DockedToChartArea = area;
            chart1.Titles.Add("").DockedToChartArea = area;
            foreach (Title titles in chart1.Titles)
            {
                titles.IsDockedInsideChartArea = false;
            }
            foreach (ChartArea areas in chart1.ChartAreas)
            {
                areas.Area3DStyle.Enable3D = true;
                areas.AxisX.LabelStyle.IsEndLabelVisible = false;                                                                                                               areas.AxisX.LabelStyle.Angle = -90;
                areas.AxisX.LabelStyle.IsEndLabelVisible = true;
                areas.AxisX.LabelStyle.Enabled = true;
               
            }
            foreach (Legend legends in chart1.Legends)
            {
                legends.Enabled = false;
            }
            foreach (Series serie in chart1.Series)
            {
                serie.ChartType = SeriesChartType.StackedColumn; 
               // change here to get the pie charts
                  // charttypes.ChartType = SeriesChartType.Pie;
                  // charttypes["LabelStyle"] = "Outside";
                  // charttypes["DoughnutRadius"] = "30";
                 //  charttypes["PieDrawingStyle"] = "SoftEdge";
                 //  charttypes.BackGradientStyle = GradientStyle.DiagonalLeft;
                   
                
                    serie["LabelStyle"] = "Outside";
                   serie["ColumnDrawingStyle"] = "SoftEdge";
                serie["LabelStyle"] = "Top";
                serie.IsValueShownAsLabel = true;
                serie.BackGradientStyle = GradientStyle.DiagonalLeft;
            }
            membervisits = visistsdataf.GetVisits(startdate, enddate);
            chart1.Series[0].Points.DataBindXY(membervisits.Rows, "Status", membervisits.Rows, "Visits");
            foreach (Series chartSeries in chart1.Series)
            {
                foreach (DataPoint point in chartSeries.Points)
                {
                    switch (point.AxisLabel)
                    {
                        case "Accepted": point.Color = Color.Green; break;
                        case "Refused": point.Color = Color.Red; break;
                    }
                    point.Label = string.Format("{0:0} - {1}", point.YValues[0], point.AxisLabel);
                }
            }
        }
     
