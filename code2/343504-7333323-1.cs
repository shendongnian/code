    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var data = e.Item.DataItem;
            var index = e.Item.ItemIndex;
    
            var row = e.Item.FindControl("row");
    
            // do something with row control
        }
    }
