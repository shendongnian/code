     ...
     Application.Current.RootVisual.MouseLeftButtonDown += RootVisual_MouseLeftButtonDown;
     this.Unloaded += Control_Unloaded;
     ...
     
     void Control_Unloaded(object sender, RoutedEventArgs e)
     {
        Application.Current.RootVisual.MouseLeftButtonDown -= RootVisual_MouseLeftButtonDown;
     }
