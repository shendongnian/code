    protected void gvOrganisms_DataBound(object sender, EventArgs e)
    {
        GridView grid = sender as GridView;
    
        if (grid != null)
        {
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);
    
            TableCell left = new TableHeaderCell();
            left.ColumnSpan = 3;
            row.Cells.Add(left);
    
            TableCell totals = new TableHeaderCell();
            totals.ColumnSpan = grid.Columns.Count - 3;
            totals.Text = "Totals";
            row.Cells.Add(totals);
    
            Table t = grid.Controls[0] as Table;
            if (t != null)
            {
                t.Rows.AddAt(0, row); // You will change this line to insert at the end!
            }
        }
    }
