    void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          string text = e.Row.Cells[1].Text;
    
          if( text.Equals("BAD") )
          {
             //do your stuff...
          }
        }
    
      }
