     protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
     if (e.Row.RowType == DataControlRowType.Header)
        {
          String coltext =  e.Row.Cells[1].Text
        }
     else if(e.Row.RowType == DataControlRowType.DataRow)
        {
              String coltext =  e.Row.Cells[1].Text
        } 
    }
