    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
      if( if (e.Row.RowType == DataControlRowType.DataRow) 
      {
        PlaceHolder plachldr = e.Row.FindControl("PlaceHolder2") as PlaceHolder;
        if(plachldr!=null)
        {
         Button btn = new Button() { ID = "btnShhow", Text = "Show" };
         plachldr.Controls.Add(btn);
        }
    
        PlaceHolder placeholder = e.Row.FindControl("PlaceHolder1") as PlaceHolder;
        if(placeholder!=null)
        {
         TextBox txt1 = new TextBox();
         placeholder.Controls.Add(txt1);
        }
       }
    
    }
