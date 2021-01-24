    private void tbCtrl_Loaded(object sender, RoutedEventArgs e)
    {
        var tabControlViewModel = new TabControlViewModel();
        tabControlViewModel.Items.Add(new ItemViewModel());
        DataContext = tabControlViewModel;
        tbCtrl.SelectedIndex = 0;
    }
