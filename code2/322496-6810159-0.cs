    chart1.Series.Add("example");
    chart1.Series["example"].ChartType = System.Windows.Forms.DataVisualization.
        Charting.SeriesChartType.Line;
    for (int i = 0; i < 20; ++i)
    {
        chart1.Series["example"].Points.Add(2 * i);
    }
