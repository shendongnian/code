	protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
	{
		if(e.Item.ItemType == ListViewItemType.DataItem)
		{
			Panel pnl = (Panel)e.Item.FindControl("pnlName");
			pnl.Visible = false;
		}
	}
