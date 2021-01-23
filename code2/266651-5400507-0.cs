    private void ClickHandler(object sender, RoutedEventArgs e)
    {
      // This is the item that you want.  Many assumptions about the types are made, but that is OK.
      MyViewModel model = ((sender as FrameworkElement).DataContext as MyViewModel);
    }
