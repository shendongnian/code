    void TapEventHandler(object sender, RoutedEventArgs e)
    {
      ItemViewModel ivm = (ItemViewModel) sender.DataContext;
      // ... find out what page/query string to navigate to based on ivm.
      NavigationService.Navigate(new Uri(/*uri here*/);
    }
