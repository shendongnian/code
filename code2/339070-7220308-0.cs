    void myGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          // Check if any of the values of mygridview row cells are empty.
          if (e.Row.Cells[0].Text == "")
          {
               e.Row.Cells[0].Text = "ERROR: Guest name is empty!"
               e.Row.Cells[0].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "red");
          }
          if (e.Row.Cells[1].Text == "")
          {
               e.Row.Cells[1].Text = "ERROR: Guest Id is empty!"
               e.Row.Cells[1].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "red");
          }
          if (e.Row.Cells[2].Text == "")
          {
               e.Row.Cells[2].Text = "ERROR: Ic number is empty!"
               e.Row.Cells[2].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "red");
          }
    
    
        }
    
      }
