    protected void Repeater_ItemDatabound(object s,EventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item 
            || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            NewAddedFiles currentItem=(NewAddedFiles)e.Item.DataItem;
            //do ur rocessing here
        }
    }
