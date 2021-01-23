    Series set1 = new Series();
    for (int i = 0; i < 10; i++) 
    {
         set1.Points.addY(x);
    }
    set1.BorderWidth = 10;
    set1.BorderDashStyle = ChartDashStyle.Solid;
    set1.ChartType = SeriesChartType.FastLine;
    set1.Color = Color.Green;
    chart1.Series.Add(set1);
    chart1.Invalidate();
