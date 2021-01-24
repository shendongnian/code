    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        TableCell cell = e.Row.Cells[2];
         cell.Text = cell.Text + “ “ + e.Row.Cells[3] + “ “ + e.Row.Cells[4] + “ “ + e.Row.Cells[5];
        cell.ColumnSpan = 4;
        e.Row.Cells[3].Visible = false;
         e.Row.Cells[4].Visible = false;
         e.Row.Cells[5].Visible = false;
    }
    }
