    [..]
    var button = new Button();
    button.Content = "SomeButtonName";
    button.MouseUp += HandleMouseUp;
    [..]
    private void HandleMouseUp(object sender, MouseButtonEventArgs e)
    {
        var senderUIControl = sender as Control;
        var contextMenu = new ContextMenu();
        var item = new MenuItem();
        item.Header = "Copy";
        item.Click += (o, a) => {
            Console.WriteLine("Copy item clicked");
        };
        contextMenu.Items.Add(item);
        senderUIControl.ContextMenu = contextMenu;
    }
