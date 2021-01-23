    protected void Page_Load(object sender, EventArgs e)
    {
        scrollerRepeater.ItemDataBound += BindScrollerItem;
        var files = Directory.GetFiles("*.jpg").Select(filename=>new FileInfo(filename));
        scrollerRepeater.DataSource = files;
        scrollerRepeater.DataBind();
    }
    private void BindScrollerItem(object sender, RepeaterItemEventArgs e)
    {
        ListItemType type = e.Item.ItemType;
        if(type != ListItemType.Item && type!=ListItemType.AlternatingItem)
        {
            return;
        }
        var file = e.Item.DataItem as FileInfo;
        if(file == null)
            return;
        var image = e.Item.FindControl("scrollerImage") as HtmlImage;
        if (image == null)
            return;
        image.Src = 
    }
