     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CommandName")
        {
          String Email = e.CommandArgument.ToString(); // will Return current Row primary key value
          //..Put deletion code here....
          //.....
         }
     }
