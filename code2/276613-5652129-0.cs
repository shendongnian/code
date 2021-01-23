        _menu = new ContextMenu();
        MenuItem item = new MenuItem();
        item.Header = "My menu item";
        item.Click += new RoutedEventHandler(item_Click);
        _menu.Items.Add(item);
