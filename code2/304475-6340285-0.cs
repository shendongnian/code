    private void Menu_MouseLeftButtonUp(object sender, RoutedEventArgs e)        
    {            
      System.Diagnostics.Debug.WriteLine(
        "Sender contains an object of type {0}", 
        sender.GetType());
      System.Diagnostics.Debug.WriteLine(
        "e.Source contains an object of type {0}", 
        e.Source.GetType());
    }
