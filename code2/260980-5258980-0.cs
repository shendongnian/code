    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "")
        {
           e.CommandArgument // will return the id 
        }        
    }
