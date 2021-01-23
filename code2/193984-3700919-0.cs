    Repeater1.ItemDataBound += (s, e) =>
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            var Button1 = e.Item.FindControl("Button1") as LinkButton;
            Button1.CommandArgument = item.ID.ToString();
        }
    };
