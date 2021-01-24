    List<MenuButton> mbButtons;
    
    private void SetUpButtons()
    {
        Random r = new Random();
    
        foreach (MenuButton item in mbButtons)
        {
            item.Tag = r.Next(0, 11);
            item.Click += MyClickEvent;
        }
    }
    
    private void MyClickEvent(object sender, RoutedEventArgs e)
    {
        var mb = (MenuButton)sender;
        int i = (int)mb.Tag;
    }
