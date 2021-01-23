    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        listmy.SelectedIndex = listmy.Items.Count - 1;
        listmy.ScrollIntoView(listmy.SelectedItem);
    } 
