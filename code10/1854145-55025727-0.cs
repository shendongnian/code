    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
       var p = Mouse.GetPosition(this);
       var element = this.InputHitTest(p) as FrameworkElement;
    
       if (element != null)
       {
          //your data object
          var result = element.DataContext;
       }
    }
