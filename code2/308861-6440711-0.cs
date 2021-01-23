    Color[] colors = new Color[] { Color.Green, Color.Red };
    foreach (Series series in Chart1.Series)
    {
        foreach (DataPoint point in series.Points)
        {
            point.LabelBackColor = colors[series.Points.IndexOf(point)];
        }
    }
