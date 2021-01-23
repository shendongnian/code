    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            // row contains current Clicked Gridview Row
            String VersionId = row.Cells[CellIndex].Text;
            .............
            .............
            //e.CommandArgument  -- this return Data Key Value
        }
    }
