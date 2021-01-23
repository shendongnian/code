    private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listBox.SelectedIndex >= 0)
        {
            (Application.Current as App).obj_list = list[listBox.SelectedIndex];
            NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.Relative)); //Navigate to detail page
    
            listBox.SelectedIndex = -1;
        }
    }
