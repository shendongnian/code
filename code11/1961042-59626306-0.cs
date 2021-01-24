    foreach (var key in instantCurves._curveList)
            {
                CheckBox series = new CheckBox();
                series.Content = key.Value;
                //series.Checked = affMatchingCurve(key.Value);
                setCurve(key.Key, key.Value);
                series.CheckedChanged += new EventHandler(series_CheckedChanged) 
                SeriesHolder.Children.Add(series);
            }
