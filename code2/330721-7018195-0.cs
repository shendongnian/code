    switch (e.Item.ItemType) {
        case ListItemType.Item:
        case ListItemType.AlternatingItem:
             Repeater r2 = (Repeater)e.Item.FindControl("rptActivity");
             r2.DataSource = dt; //Error on this line.
             r2.DataBind();
     }
