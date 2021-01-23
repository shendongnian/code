    _menu = new ContextMenu();
    MenuItem item = new MenuItem();
    item.Click += MyClickHandler;
    item.Header = "My Menu Item";
    _menu.Items.Add(item);
