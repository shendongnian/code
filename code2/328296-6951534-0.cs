    void grdRules_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="imagebutton")
        {
          //insert row
          int id = int.Parse(e.CommandArgument.ToString());
          ImageButton imgButton = 
                 (ImageButton)grdRules.Rows[id].FindControl("imgButton");      
    
         imgButton.Visible =false;
        }
    }
