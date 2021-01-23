    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            e.CommandArgument // Return Primary key
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            row.Cells[0].///
            row.Cells[1].///
            ................
        }
    }
