    try
    {
        Excel.Worksheet excelWorksheet = workbook.ActiveSheet as Excel.Worksheet;
        Excel.Range formulaCell = excelWorksheet.Cells.SpecialCells(
            Excel.XlCellType.xlCellTypeFormulas, Type.Missing);
    
        Excel.Range cell;
        foreach (var fc in formulaCell)
        {
            cell = fc as Excel.Range;
            string s1 = cell.Formula as string;
            int c = cell.Column;
            int r = cell.Row;
            // Gives formula text and location of formula.
        }
    }
    catch (Exception)
    {
        ; // Throws an exception if there are no results.
          // Probably should ignore that exception only
    }
