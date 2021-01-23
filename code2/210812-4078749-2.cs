    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		Panel panel1 = e.Item.FindControl("Panel1") as Panel;   //assume your panel name is Panel1
    		if (panel1 != null)
    		{
    			Label LblHead = panel1.FindControl("LblHead") as Label;
    			if (LblHead != null)
    			{
    				string LanguageID = Globals.GetSuitableLanguage(Page);
    				if (LanguageID == "ar")
    				{
    					LblHead.Attributes.Add("CssClass", "hed_logo2");
    				}
    			}
    		}
    	}
    }
