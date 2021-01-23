    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            String productId = row.Cells[0].Text; // I suposed your product Id in very first column in gridview
            //Delete Code goes here..........
            ...........................
        }
    }
