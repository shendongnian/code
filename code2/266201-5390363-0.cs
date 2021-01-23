      Image img = new Image();
      img.Source = new BitmapImage(new Uri("foo.png"));
      
      StackPanel stackPnl = new StackPanel();
      stackPnl.Orientation = Orientation.Horizontal;
      stackPnl.Margin = new Thickness(10);
      stackPnl.Children.Add(img);
      Button btn = new Button();
      btn.Content = stackPnl;
