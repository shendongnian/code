    public void outerFunction(object sender, RepeaterItemEventArgs  e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		Label myLabel =  (Label) e.Item.FindControl("pageLabel");
    		myLabel.Text = "HELLO World";
    	}
    }
