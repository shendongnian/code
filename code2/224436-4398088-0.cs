    siteMapAsBulletedList.ItemDataBound += new RepeaterItemEventHandler(siteMapAsBulletedList_ItemDataBound);
    
    ...
    
    void siteMapAsBulletedList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Footer)
    	{
    		DropDownList ddlChangeUser = (DropDownList)e.Item.FindControl("ddlChangeUser");
    		if (ddlChangeUser != null) {
                       ...
    		}
    	}
    }
