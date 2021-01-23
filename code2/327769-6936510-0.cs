     protected void grid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].ColumnSpan = 2;
            //now make up for the colspan from cell2
            e.Row.Cells.RemoveAt(4);
        }
    }
