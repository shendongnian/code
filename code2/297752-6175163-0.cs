        ContextMenu menu = new ContextMenu();
        MenuItem item = new MenuItem();
        menu.MenuItems.Add(0, item);
        if (menu.MenuItems.Contains(item))
            Console.WriteLine("The item exists");
