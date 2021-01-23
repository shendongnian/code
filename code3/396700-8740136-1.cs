    public void PopulateMenu(string fileName, ContextMenuStrip parent)
        {
            ToolStripMenuItem newMenu = new ToolStripMenuItem(fileName);
            newMenu.DropDownItems.Add(new ToolStripMenuItem("View File"));
            newMenu.DropDownItems.Add(new ToolStripMenuItem("Delete File"));
            newMenu.DropDownItems.Add(new ToolStripMenuItem("Remove File"));
    
            parent.Items.Add(newMenu);
        }
