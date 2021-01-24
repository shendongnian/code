    var viewModel = new SalesViewModel();
    
    chart.Series.Add(new ColumnSeries()
                {
                    ItemsSource = viewModel.SalesData,
                    XBindingPath = "Year",
                    YBindingPath = "Target"
                });
