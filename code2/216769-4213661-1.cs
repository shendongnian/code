    protected void myRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if(e.Item.ItemIndex == selectedIndex)
                {
                   ((LinkButton)e.Item.FindControl("lnk1")).Visible = false;
                   ((Label)e.Item.FindControl("label1")).Visible = true;
                }
            }
        }
 
