    foreach (RepeaterItem item in rptItems.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            var checkBox = (CheckBox)item.FindControl("ckbActive");
    
            //Do something with your checkbox...
            checkBox.Checked = true;
        }
    }
