    private void Menu_Opening(object sender, object e)
    {
        TextCommandBarFlyout myFlyout = sender as TextCommandBarFlyout;
      
        if (myFlyout != null && myFlyout.Target == TextBox)
        {
            AppBarButton searchCommandBar = new AppBarButton() { Icon = new SymbolIcon(Symbol.Find), Label = "Search With" };
            searchCommandBar.Click += SearchCommandBar_Click;
            myFlyout.PrimaryCommands.Add(searchCommandBar);
      
        }
    }
    
    private void SearchCommandBar_Click(object sender, RoutedEventArgs e)
    {
      
    }
