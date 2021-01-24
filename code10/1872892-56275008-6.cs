    private void Chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
        Chart chart = sender as Chart;  //*
        Series s = chart.Series[0];  // make sure to pick the right one!
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY2;  // !!
        var pts = s.Points.Select(x => 
            new PointF((float)ax.ValueToPixelPosition(x.XValue),
                       (float)ay.ValueToPixelPosition(x.YValues[0])));
        using (Pen pen = new Pen(s.Color, s.BorderWidth))
                e.ChartGraphics.Graphics.DrawLines(pen, pts.ToArray());
    }
