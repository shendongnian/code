    protected void dlList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
            if (e.Item.ItemType == ListItemType.Header)
                 .....
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 ........
    }
