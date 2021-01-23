    myTable.Rows[0].Cells[i].ColSpan = 2;
    myTable.Rows[0].Cells[i].RowSpan = 2;
    myTable.Rows[0].Cells.RemoveAt(i + 1)
    myTable.Rows[1].Cells.RemoveAt(i)
    myTable.Rows[1].Cells.RemoveAt(i + 1)
