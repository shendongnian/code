    foreach(var item in AdminGetAllRPT.Items)
    {
        if (item.ItemType == RepeaterItemType.Item || item.ItemType == RepeaterItemType.AlternatingItem)
        {
            var hiddenField = item.FindControl("hiddenFieldid") as HiddenField;
            //Do Stuff
        }
    }
