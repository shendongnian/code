    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if(row.RowType == DataControlRowType.Header)
        {
            foreach(TableCell cell in row.Cells)
            {
                if(DateTime.TryParse(cell.Text, out var date))
                {
                    ColIndexes.Add(row.Cells.GetCellIndex(cell));
                }
            }
        }
        if(row.RowType == DataControlRowType.DataRow)
        {
            foreach (var index in ColIndexes)
            {
                var cell = row.Cells[index];
                if (string.IsNullOrWhiteSpace(cell.Text))
                    cell.Text = "Absent";
            }
        }
    }
