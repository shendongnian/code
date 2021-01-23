    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
           
           if (e.CommandName == "Select")
            {
              int MyFileID = e.CommandArgument;
           //Now Perfrom here ur desired action
           }
