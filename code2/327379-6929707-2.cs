    protected void myrepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)
        {
            e.Item.FindControl("btnDelete").Visible = false;
        }
    }
