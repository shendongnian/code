    var series = chart1.Series[0]; //series object
    var chartArea = chart1.ChartAreas[series.ChartArea];
    chartArea.AxisY.StripLines.Add(new StripLine
                                               {
                                                   BorderDashStyle = ChartDashStyle.Dash,
                                                   BorderColor = Color.DarkBlue,
                                                   StripWidth = 80//Here is your y value
                                               });
