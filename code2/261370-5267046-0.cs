    ContextMenu = new ContextMenu();
    foreach (var column in this.dataGridView.Columns)
    {
        this.AddContextMenuItem(ContextMenu, column.Name, column.Visible);
    }
    private void AddContextMenuItem(ContextMenu contextMenu,
                                    string columnName,
                                    bool visible)
    {
        var menuItem = new MenuItem(columnName,
            new EventHandler(this.ContextMenu_onClick)) { Checked = visible };
        contextMenu.MenuItems.Add(menuItem);
    }
