    var contextMenu = new ContextMenu();
    contextMenu.MenuItems.Add(new MenuItem("Copy", (s, ea) => textBox1.Copy()));
    contextMenu.MenuItems.Add(new MenuItem("Paste", (s, ea) => textBox1.Paste()));
    contextMenu.MenuItems.Add(new MenuItem("Undo", (s, ea) => textBox1.Undo()));
    contextMenu.MenuItems.Add(new MenuItem("Select All", (s, ea) => textBox1.SelectAll()));
    ....
    
    textBox1.ContextMenu = contextMenu;
