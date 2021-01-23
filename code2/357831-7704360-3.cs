    protected void Gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
             int selectedOrderId = Convert.ToInt32(e.CommandArgument);
             // ... 
        }
    }
