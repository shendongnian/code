    for (int row = 0; row < range.Rows.Count; row++)
    {
        for (int column; column < range.Columns.Count; column++)
        {
            // Offset indexing into range.Cells as Excel is 1-based
            Excel.Range range = (Excel.Range) range.Cells[row + 1, column + 1];
            myArray[column, row] = (string) range.Value2;
        }
    }
