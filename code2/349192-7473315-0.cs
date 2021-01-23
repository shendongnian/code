    public int LastRow()
    {
          // This version also returns cells with formatting
          // return (int)worksheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, System.Reflection.Missing.Value).Row;
    
          // This version seems to also not work but dont know why
          // return (int)worksheet.UsedRange.Rows.Count;
    
          // This is the most reliable so far
          return (int)worksheet.Cells.Find("*", worksheet.Cells[1, 1], XlFindLookIn.xlValues, XlLookAt.xlWhole, XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious, missing, missing, missing).Row;
    }
