    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "newDelete ")
        {
          e.CommandArgument // will Return current Row primary key value
            ..............
          //Write Delete custom code here
          .............
        }
    }
