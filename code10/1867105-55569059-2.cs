    private void Chart1_MouseClick(object sender, MouseEventArgs e)
    {
        var hitt = chart1.HitTest(e.X, e.Y);
        if (hitt.ChartElementType == ChartElementType.LegendItem)
        {
            Series s = hitt.Series;
            if (s.Color == Color.Transparent)
            {
                s.Color = (Color)s.Tag;
            }
            else
            {
                s.Tag = s.Color;
                s.Color = Color.Transparent;
            }
        }
    }
