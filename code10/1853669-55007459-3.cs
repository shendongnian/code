    private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        Series s = chart1.Series[0];
        if (s.Points.Count <= 0) return;
        Graphics g = e.ChartGraphics.Graphics;
        var ca = chart1.ChartAreas[0];
        Axis ay = ca.AxisY;
        DateTime d1 = DateTime.FromOADate(ay.Minimum);
        DateTime d2 = DateTime.FromOADate(ay.Maximum);
        int x1 = (int)ay.ValueToPixelPosition(ay.Minimum);
        int x2 = (int)ay.ValueToPixelPosition(ay.Maximum);
        int y = (int)ca.AxisX.ValueToPixelPosition(ca.AxisX.Minimum);
        using (SolidBrush b = new SolidBrush(Color.FromArgb(11, 222, 222, 111)))
            g.FillRectangle(b, x1, y, x2 - x1, 60);  // 60 pixels large, calculate what you need!
    }
