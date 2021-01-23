    private void click(object sender, RoutedEventArgs args)
    {
      var textBox = sender as TextBox;
      if(textBox == null)
         return;
    
      if(textBox.Text.Equals("hi"))
      {
         // Do Something Crazy!
      }
    }
