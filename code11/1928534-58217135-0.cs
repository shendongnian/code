    private void chart_MouseMove(object sender, MouseEventArgs e)
    {
        ChartArea ca = chart.ChartAreas[0];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        Series s = chart.Series[0];
        // the values at the mouse pointer:
        double valx = ax.PixelPositionToValue(e.X);
        double valy = ay.PixelPositionToValue(e.Y);
        // the deltas on the x-axis (with index):
        var ix = s.Points.Select((x, i) => new { delta = Math.Abs(x.XValue - valx), i })
                                  .OrderBy(x => x.delta).First().i;
        var dpX = s.Points[ix];
        // set/reset colors
        if (dpXaxis != null) dpXaxis.Color = s.Color;
        dpXaxis = dpX;
        dpXaxis.Color = Color.LawnGreen;
    }
