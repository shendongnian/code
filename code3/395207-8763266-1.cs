    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e) 
    { 
        GridViewRow row = new GridViewRow(e.Row.RowIndex+1, -1, DataControlRowType.DataRow, DataControlRowState.Insert); 
        TableCell cell = new TableCell();
        cell.ColumnSpan = some_span;
        cell.HorizontalAlign = HorizontalAlign.Left;
        
        Control c = new Control(); // some control
        cell.Controls.Add(c);
        row.Cells.Add(cell);
        ((GridView)sender).Controls[0].Controls.AddAt(some_index, row);
    } 
