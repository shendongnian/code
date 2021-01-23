    Series ser2 = chart1.Series.Add("line");
    ser2.ChartType = SeriesChartType.Line;
    Random r = new Random(8);
    ser2.Points.AddXY(0, 10);
    for (int i = 1; i < 60; i++ )
    {
        int v = 10 + r.Next(10);
        int p = ser2.Points.AddXY(i, v);
        ser2.Points[p].Color =
            ser2.Points[p - 1].YValues[0] < ser2.Points[p].YValues[0] ?
            Color.Black : Color.Red;
    }
