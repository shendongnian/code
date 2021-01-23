    // Define section
    var toolbar = new Toolbar();
    toolbar.MenuItemClick += MenuItemClickHandler;
...
    MenuItemClickHandler(object sender, Toolbar.ToolBarCommands item)
    {
        switch(item)
        {
            case Toolbar.ToolBarCommands.Naprej:
                // Naperej handler
            break;
            case Toolbar.ToolBarCommands.Nazaj:
                // Nazaj handler
            break;
            case Toolbar.ToolBarCommands.Novo:
                // Novo handler
            break;
        }
    }
        
