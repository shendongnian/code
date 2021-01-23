    protected void Row_DataItem(object row, RepeaterItemEventArgs args)
    {
        if (args.Item.ItemType == ListItemType.AlternatingItem || args.Item.ItemType == ListItemType.Item)
        {
            var item = (DataItemPOCO)args.Item.DataItem;
            var link = (HyperLink)args.Item.FindControl("HyperLink1");
            link.Text = item.LinkText;
            link.NavigateUrl = item.URL;
        }
    }
