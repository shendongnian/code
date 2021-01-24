    Series s = chart1.Series[0];
    s.ChartType = SeriesChartType.Column;
    s.IsValueShownAsLabel = true;
    for (int i = 0; i < 30; i++)
    {
        int p = s.Points.AddXY(i, rnd.Next(30));
        DataPoint pt = s.Points[p];
        if (pt.YValues[0] >   10) 
        {
           pt.SetCustomProperty("LabelStyle", "Bottom");
           pt.LabelForeColor = Color.White;
        }
        else pt.LabelBackColor = Color.White;
    }
