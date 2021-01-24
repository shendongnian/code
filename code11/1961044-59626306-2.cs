    foreach (var key in instantCurves._curveList)
    {
        CheckBox series = new CheckBox();
        series.Content = key.Value;
        series.Checked += SeriesChecked;
        series.Unchecked += SeriesUnchecked;
        setCurve(key.Key, key.Value);
        SeriesHolder.Children.Add(series);
    }
