    protected void DdlSelected(object sender, EventArgs e)
    {
    	var ddl = (DropDownList)sender;
    	var row = (GridViewRow)ddl.NamingContainer;
    	var grid = (GridView)row.NamingContainer;
    	var index = row.RowIndex + 1;
    	while (index < grid.Rows.Count) {
    		var nextRow = grid.Rows[index];
    		var nextDdl = (DropDownList)nextRow.FindControl("ddl");
    		nextDdl.Items.Clear();
    		foreach (ListItem item in getDllSource()) {
    			if (ddl.SelectedItem == null || !ddl.SelectedItem.Equals(item)) {
    				nextDdl.Items.Add(item);
    			}
    		}
    		index += 1;
    	}
    }
