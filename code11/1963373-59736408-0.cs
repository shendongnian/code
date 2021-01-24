    private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var vm = DataContext as YourViewModel;
        dataGrid.Columns.Clear();
        if (vm.Rows != null && vm.Rows.Count > 0)
        {
            var setups = vm.Rows[0].Setups;
            foreach (var setup in setups)
            {
                dataGrid.Columns.Add(new DataGridTextColumn { Header = setup.Name, Binding = new Binding("Content ") });
            }
        }
        dataGrid.ItemsSource = vm.Rows;
    }
