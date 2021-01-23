    protected void myRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               bllUsers obj = e.Item.DataItem as bllUsers;
               ((Label)e.Item.FindControl("ldefault")).Visible = obj.isDefault; 
               ((Button)e.Item.FindControl("btnMakeDefault")).Visible = ! obj.isDefault; 
            }
        }
