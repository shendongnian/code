    myChart.ApplyPaletteColors();
    
    foreach (var series in myChart.Series)
    {
        foreach (var point in series.Points)
        {
            point.Color = Color.FromArgb(220, point.Color);
        }
    }
