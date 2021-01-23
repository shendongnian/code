    protected void rptItemCreated(Object Sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType==ListItemType.Header)
        {
            HtmlAnchor HyperLinkID1=(HtmlAnchor)e.Item.FindControl("HyperLinkID1");
            HyperlinkID1.ImageUrl = IsPostBack?"asc.jpg":"asc.jpg;
        }
    }
