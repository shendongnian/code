     void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          // format the email, provided cell 1 is email
          e.Row.Cells[1].Text=e.Row.Cells[1].Text.substring(0,e.Row.Cells[1].Text.indexof("@"));
    
        }
    
      }
