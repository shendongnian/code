    void OnLoaded(object sender, RoutedEventArgs e)
    {
        AttachedEvents.AddClickHandler((sender as ListBoxItem), HandleClick);
    }
    
    void HandleClick(object sender, RoutedEventArgs e) 
    {
        if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
        {
            Console.WriteLine("Ctrl + Clicked!");
        }
    }
