    public MainWindow()
    {
      ..
      this.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(this.MenuItemClick));
    }
    private void MenuItemClick(object sender, RoutedEventArgs e)
    {
       MessageBox.Show("Clicked");
    }
