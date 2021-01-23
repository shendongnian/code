    ContextMenuStrip contexMenu = new ContextMenuStrip();
    
    contexMenu.Items.Add("Edit ");
    contexMenu.Items.Add("Delete ");
    contexMenu.Show();
    contexMenu.ItemClicked += new ToolStripItemClickedEventHandler(
        contexMenu_ItemClicked);
    
    // ...
    
    void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
        ToolStripItem item = e.ClickedItem;
        // your code here
    }
