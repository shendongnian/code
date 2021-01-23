    Repeater1.DataSource = List;
    Repeater1.DataBind();
    
    Repeater1.ItemDataBound += (s, e) =>
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            var item = e.Item.DataItem as Person;
            var Button1 = e.Item.FindControl("Button1") as LinkButton;
        }
    };
