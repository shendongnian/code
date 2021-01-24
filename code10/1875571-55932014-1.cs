    private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ShareListBoxItem.IsSelected)
           appFrame.Navigate(typeof(page1));//navigating to page1
        else if (FavoritesListBoxItem.IsSelected)
           appFrame.Navigate(typeof(page2));//navigating to page2
    }
    private void Back_Click(object sender, RoutedEventArgs e)
    {
       if (appFrame.CanGoBack)
          appFrame.GoBack();
    }
