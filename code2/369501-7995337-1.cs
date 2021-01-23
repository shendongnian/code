	protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
	    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
	    {
                Label activeLabel = (Label)e.Item.FindControl("ActiveLabel");
                //Format label text as required
	    }
	}
    
