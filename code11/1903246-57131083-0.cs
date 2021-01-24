    var btn = new Button
               {
                   Name = "write_btn" + i.ToString(),
                   VerticalAlignment = VerticalAlignment.Top,
                   Margin = new Thickness(5),
                   Content = "Write",
                   Height = 55,
                   Width = 80
               };
     btn.Click += new RoutedEventHandler(home_read_click);
     option_row.Children.Add(btn);
    
