     protected void SecondGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
               FirstGrid.DataBind()
            }
       }
