     public string Message
     {
         get { return (string)GetValue(MessageProperty); }
         set { SetValue(MessageProperty, value); }
     }
     public static readonly DependencyProperty MessageProperty =
         DependencyProperty.Register("Message", typeof(string), 
         typeof(MainWindow), new UIPropertyMetadata(String.Empty));
