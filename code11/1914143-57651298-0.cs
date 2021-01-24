            rangeBarChart.Series.Clear();
            // Create two range bar series.
            Series series1 = new Series("Task1", ViewType.RangeBar);
            Series series2 = new Series("Task2", ViewType.RangeBar);
            series1.CrosshairLabelPattern = "{S}:{V1:HH:mm}--{V2:HH:mm}";
            series2.CrosshairLabelPattern = "{S}:{V1:HH:mm}--{V2:HH:mm}";
            //Add values to series
            series1.ValueScaleType = ScaleType.DateTime;
            series2.ValueScaleType = ScaleType.DateTime;
            series1.Points.Add(new SeriesPoint("A", Convert.ToDateTime("2019-08-24 8:00"), Convert.ToDateTime("2019-08-24 17:00")));
            series2.Points.Add(new SeriesPoint("A", Convert.ToDateTime("2019-08-24 9:00"), Convert.ToDateTime("2019-08-24 10:00")));
            series2.Points.Add(new SeriesPoint("A", Convert.ToDateTime("2019-08-24 13:00"), Convert.ToDateTime("2019-08-24 14:00")));
            // Add both series to the chart.
            rangeBarChart.Series.AddRange(new Series[] { series1, series2 });
            ((XYDiagram)rangeBarChart.Diagram).Rotated = true;
