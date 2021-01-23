    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.Header)
       {
         TableHeaderCell NewCell = new TableHeaderCell();
         NewCell.Text = "Header Text";
         e.Row.Cells.AddAt(4(Index of Cell where you want to add cell), NewCell);
       }
 
    if (e.Row.RowType == DataControlRowType.DataRow)
         {
           TableCell NewCell= new TableCell(); 
           NewCell.ID = "NewCell";
           NewCell.Text = "Text value of cell which you want to display";
           e.Row.Cells.AddAt(4, NewCell);
         }
     }
