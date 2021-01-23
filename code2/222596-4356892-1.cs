    protected void GridView1_SelectedIndexChanging(object sender, EventArgs e) {
        string PhotoPath = "";
        // Get the currently selected row. Because the SelectedIndexChanging event
        // occurs before the select operation in the GridView control, the
        // SelectedRow property cannot be used. Instead, use the Rows collection
        // and the NewSelectedIndex property of the e argument passed to this 
        // event handler.
        GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
    
        PhotoPath = row.Cells[5].Text;
    }
