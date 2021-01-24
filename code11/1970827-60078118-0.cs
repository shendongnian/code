    OxyPlot.Wpf.LineSeries ls = new OxyPlot.Wpf.LineSeries();
    ls.StrokeThickness = 1;
    ...
    List<DataPoint> dataPoints = new List<DataPoint>();
    dataPoints.Add(new DataPoint(0, 1));
    dataPoints.Add(new DataPoint(10, 100));
    dataPoints.Add(new DataPoint(20, 200));
    dataPoints.Add(new DataPoint(30, 300));
    ls.ItemsSource = dataPoints;
    TestPlot.Series.Add(ls);
