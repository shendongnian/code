     using Microsoft.Office.Interop.Excel;
      ApplicationClass app = null;
      Workbook workBook = null;
      CultureInfo ci = Thread.CurrentThread.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      app = new ApplicationClass();
      workBook = app.Workbooks.Open(pathToExcelFile, Type.Missing, true, Type.Missing,      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
      Range range = ((Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[sheet.Index]).UsedRange;
     
      for (int i = 0; i < range.Rows.Count - 1; i++)
      {
          Index++;
          string val  = ((Range)range.Cells[rowIndex, colIndex]).Value2;
      }
