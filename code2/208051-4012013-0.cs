    protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HtmlAnchor nameAnchor = (HtmlAnchor)e.Item.FindControl("name");
            nameAnchor.Attributes.Add("class", "sprite id" + (e.Item.ItemIndex + 1));
        }
    }
