    private void AButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow.ViewModel.Instance.Items.Clear();
        var search = Search(searchParam);
        if (search != null)
            foreach (var x in search)
                MainWindow.ViewModel.Instance.Items.Add(x);
    }
