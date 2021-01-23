    protected void rGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header) // For Header
        {
            TextBox txt = e.Item.FindControl("txt") as TextBox;
        }
    } 
