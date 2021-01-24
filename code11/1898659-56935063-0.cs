    protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            DataRowView row = (DataRowView)e.Item.DataItem;
        
    	    ....
            Label lblProfileID = e.Item.FindControl("lblProfileID") as Label;
            string strID = lblProfileID.Text;
            ...
        }
    }
