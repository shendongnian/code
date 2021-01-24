    private static bool RowIsEmpty(Range range)
    {
      foreach (object obj in (object[,])range.Value2)
      {
        if (obj != null && obj.ToString() != "")
        {
          return false;
        }
      }
      return true;
    }
    private static bool CellIsEmpty(Range cell)
    {
      if (cell.Value2 != null && cell.Value2.ToString() != "")
      {
        return false;
      }
      return true;
    }
    private Tuple<int, int> ExcelFindStartCell()
    {
      var excelApp = new Microsoft.Office.Interop.Excel.Application();
      excelApp.Visible = true;
      Workbook workbook = excelApp.Workbooks.Open("test.xlsx");
      Worksheet worksheet = excelApp.ActiveSheet;
      // Go through each row.
      for (int row = 1; row < worksheet.Rows.Count; row++)
      {
        Range range = worksheet.Rows[row];
        // Check if the row is empty.
        if (RowIsEmpty(range))
        {
          continue;
        }
        // Check if the row contains any merged cells, if so we'll assume it's
        // some kind of header and move on.
        object mergedCells = range.MergeCells;
        if (mergedCells == DBNull.Value || (bool)mergedCells)
        {
          continue;
        }
        // Find the first column that contains text in this row.
        for (int col = 1; col < range.Columns.Count; col++)
        {
          Range cell = range.Cells[1, col];
          if (CellIsEmpty(cell))
          {
            continue;
          }
          // Now check if the cell to the right also contains text.
          Range rightCell = worksheet.Cells[row, col + 1];
          if (CellIsEmpty(rightCell))
          {
            // No text in right cell, try the next row.
            break;
          }
          
          // Now check if cell below also contains text.
          Range bottomCell = worksheet.Cells[row + 1, col];
          if (CellIsEmpty(bottomCell))
          {
            // No text in bottom cell, try the next row.
            break;
          }
          // Success!
          workbook.Close();
          excelApp.Quit();
          return new Tuple<int, int>(row, col);
        }
      }
      // Didn't find anything that matched the criteria.
      workbook.Close();
      excelApp.Quit();
      return null;
    }
