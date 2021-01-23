    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        RectangleF ipp = InnerPlotPositionClientRectangle(chart1, chart1.ChartAreas[0]);
        using (Graphics g = chart1.CreateGraphics())
            g.DrawEllipse(Pens.Red, new RectangleF(ipp.Location, ipp.Size));
    }
