    void hideAllSeries(Chart chart)
    {
        chart.ApplyPaletteColors();
        foreach (Series s in chart.Series)
        {
            if (s.Color != Color.Transparent) s.Tag = s.Color;
            s.Color = Color.Transparent;
        }
    }
