    void rptItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var checkBox = (CheckBox) e.Item.FindControl("ckbActive");
    
            //Do something with your checkbox...
            checkBox.Checked = true;
        }
    }
