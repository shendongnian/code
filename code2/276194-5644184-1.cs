    protected void GridView1_RowDataBound(object o, GridViewRowEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item ||
    	    e.Item.ItemType == ListItemType.AlternatingItem ||
    	    e.Item.ItemType == ListItemType.Header)
        {
            //Set formatting for the Price cell
    	    //Assume cell is at index 4
            var cell = e.Item.Controls[4] as TableCell;
    	    cell.HorizontalAlign = HorizontalAlign.Right;
    	}
    }
