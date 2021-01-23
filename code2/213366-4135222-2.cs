     protected void Datalist_Categories_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
        string LanguageID = Globals.GetSuitableLanguage(Page);
    
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
    		Techgr1 = e.Item.FindControl("TechnologyGr") as HtmlGenericControl;
    	}
    
        GridView gridfeature = (GridView)e.Item.FindControl("grid_features");
    	
    		foreach (DataControlField column in gridfeature.Columns)
    		{
    			column.HeaderText = Globals.Translate(column.HeaderText, LanguageID);
    			if(Techgr1 != null)
    			{
    				Techgr1.Attributes.Add("Class", "ff");
    			}
    		}
    	
    }
