kunden_view.OnRowDataBound += kunden_view_RowDataBound;
    protected void kunden_view_RowDataBound(Object sender, GridViewRowEventArgs e)
    {        
         if(e.Row.RowType == DataControlRowType.DataRow)
         {
             LinkButton temp = new LinkButton();
             temp.ID = "Button" + i;
             temp.Text = "Drucker";
             temp.Click += drucker_button_click;
             temp.Width = 20;
             e.Row.Cells[3].Controls.Add(temp);        
          }    
     }
