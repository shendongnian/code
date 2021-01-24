    private void MainEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var keyword = MainEntry.Text;
        NameListView.ItemsSource = adressnames.Where(name => name.Contains(keyword));
    }
