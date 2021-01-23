    private void ContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        foreach (var item in (sender as ContextMenu).Items)
        {
            if(item is MenuItem)
            {
               //set the command target to whatever you like here
               (item as MenuItem).CommandTarget = this;
            } 
        }
    }
