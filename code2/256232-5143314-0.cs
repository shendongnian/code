    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow row = new GridViewRow(e.Row.RowIndex, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell = new TableCell();
            cell.Controls.Add(new Label { Text = "Header" }); //as needed
            row.Cells.Add(cell);
            Table tbl = (e.Row.Parent as Table);
            tbl.Controls.AddAt(e.Row.RowIndex * 2 + 1, row);            
        }
    }
