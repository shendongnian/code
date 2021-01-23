    private void FilterMenuText_TextChanged(object sender, EventArgs e)
    {
        foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
        {
            menuItem.Visible = MenuItemHasChildWithName(menuItem, FilterMenuText.Text);
        }
    }
    private bool MenuItemHasChildWithName(ToolStripMenuItem menuItem, string name)
    {
        if (!menuItem.HasDropDownItems)
        {
            return false;
        }
        bool matchFound = false;
        foreach (ToolStripMenuItem childMenuItem in menuItem.DropDownItems)
        {
            if (childMenuItem.Text.ToUpper().Contains(name.ToUpper()))
            {
                matchFound = true;
                break;
            }
            if (childMenuItem.HasDropDownItems)
            {
                return MenuItemHasChildWithName(childMenuItem, name);
            }
        }
        return matchFound;
    }
