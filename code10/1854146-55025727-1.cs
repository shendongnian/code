    private void ContextMenu_Opened(object sender, RoutedEventArgs e)
    {
       var p = Mouse.GetPosition(this);
       var element = this.InputHitTest(p) as FrameworkElement;
    
       if (element != null)
       {
          //your data object
          ((ContextMenu)sender).DataContext = element.DataContext;
       }
    }
    
    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
       var boundObject = ((MenuItem)sender).DataContext;
    }
