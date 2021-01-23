    TableRow tRow = new TableRow();
    myTable.Rows.Add(tRow);
    foreach (TableCell cell in myTable.Rows[1].Cells)
    {
        TableCell tCell = new TableCell();
        tCell.Text = cell.Text;
        tRow.Cells.Add(tCell);
     }
