    private TableRow CopyTableRow(TableRow row)
    {
      
        TableRow newRow = new TableRow();
        foreach (TableCell cell in row.Cells)
        {
            TableCell tempCell = new TableCell();
            foreach (Control ctrl in cell.Controls)
            {
                tempCell.Controls.Add(ctrl);
            }
            tempCell.Text = cell.Text;
            newRow.Cells.Add(tempCell);
        }
        return newRow;
    }
