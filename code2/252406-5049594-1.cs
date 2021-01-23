    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        // Find the hidden field   
        HiddenField _hdn =
        (HiddenField)e.Item.FindControl("HiddenField Id Put Here"); 
    }
