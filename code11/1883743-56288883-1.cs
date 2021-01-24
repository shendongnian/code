      public void AddTb()
      { 
             if(MySimpleStringProperty != "konzole")
                 return;
                TextBox tb2 = new TextBox();
                tb2.TextWrapping = TextWrapping.Wrap;
                tb2.Width = 60;
                tb2.Height = 23;
                tb2.Foreground = Brushes.White;
                tb2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x36, 0x4d, 0x63));
                tb2.Margin = new Thickness(0, 0, 10, 229);
                Grid.Children.Add(tb2);
        
       }
