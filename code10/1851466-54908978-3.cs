     protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
     {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          string[] docs = e.Row.Cells[3].Text.Split(' ');
          
          var lt = (Literal)e.Row.Cells[3].FindControl("ltMarkup");
          foreach(var d in docs)
              lt.Text +=  String.Format("<a href='{0}'>Link {0}</a><br/>", d);
        }
     }
