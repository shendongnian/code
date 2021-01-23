    foreach (var item in ReportListViewModel.ReportSections)
    {
        var series = new LineSeries();
        series.SetBinding(DataPointSeries.ItemsSourceProperty, new Binding("ItemList"));
        series.IndependentValuePath = "Date";
        series.DependentValuePath = item.BindingPath;
        series.Title = item.Text;
        chart.Series.Add(series);
    }
