    void StripLineTagger(Chart chart, bool beforeSer)
    {
        char sep = '\v';
        var axes = new List<Axis> { chart.ChartAreas[0].AxisX, chart.ChartAreas[0].AxisX2,
        chart.ChartAreas[0].AxisY, chart.ChartAreas[0].AxisY2};
        foreach (var ax in axes)
            foreach (var sl in ax.StripLines)
            {
                if (beforeSer) sl.Text = sl.Text + sep + sl.Tag.ToString();
                else
                {
                    var p = sl.Text.Split(sep);
                    sl.Text = p[0];
                    sl.Tag = p[1];
                }
        }
    }
