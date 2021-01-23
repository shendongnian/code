    protected void rptArticleContent_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
    	switch (e.Item.ItemType) {
    		case ListItemType.Item:
    		case ListItemType.AlternatingItem:
    
    			string Links = e.Item.DataItem("Links");
    			string[] LinksStr = Links.Split(";");
    
    			Literal Ltl = e.Item.FindControl("Ltl");
    			int Inc = 1;
    			foreach (string item in LinksStr) {
    				Ltl.Text += string.Format("<a href='{0}'>Link {1}</a>", item, Inc);
    				Inc += 1;
    			}
    
    
    			break;
    	}
    
    }
