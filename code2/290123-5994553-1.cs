    if (excelRange!= null)
    {
       int nRows = excelRange.Rows.Count;
       int nCols = excelRange.Columns.Count;
       for (int iRow = 1; iRow <= nRows; iRow++)
       {
          for (int iCount = 1; iCount <= nCols; iCount++)
          {
             excelRange= (Microsoft.Office.Interop.Excel.Range)xlSheet.Cells[iRow, iCount];
             String text = excelRange.Text;
          }
       }
    }
