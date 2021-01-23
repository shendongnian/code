    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName = "cmdName")
        {
            var arg = e.CommandArgument;
    
            // use arg to filter GridView2's DataSource
            GridView2.DataSource = FilteredDataSource;
            GridView2.DataBind();
            // show GridView2 if it's hidden.
        }
    }
