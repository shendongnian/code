    private void MainSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var keyword = MainSearchBar.Text;
        NameListView.ItemsSource = adressnames.Where(name => name.Contains(keyword));
    }
