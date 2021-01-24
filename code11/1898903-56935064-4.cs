    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var viewModel = this.DataContext as TestViewModel;
      var orderedValues = viewModel.Values.OrderBy(value => value).ToList();
      viewModel.Values = new ObservableCollection<double>(orderedValues);
    }
