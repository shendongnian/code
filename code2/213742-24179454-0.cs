    Microsoft.Office.Interop.Excel.Application oXL;
    Microsoft.Office.Interop.Excel.Workbook mWorkBook;
    Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
            
    oXL = new Microsoft.Office.Interop.Excel.Application();
    oXL.Visible = true;
    oXL.DisplayAlerts = false;
    mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    //Get all the sheets in the workbook
    mWorkSheets = mWorkBook.Worksheets;
    foreach (Microsoft.Office.Interop.Excel.Worksheet pivotSheet in mWorkSheets)
    {
        Microsoft.Office.Interop.Excel.PivotTables pivotTables = pivotSheet.PivotTables();
        int pivotTablesCount = pivotTables.Count;
        if (pivotTablesCount > 0)
        {
            for (int i = 1; i <= pivotTablesCount; i++)
            {
                pivotTables.Item(i).RefreshTable(); //The Item method throws an exception
            }
        }
    }     
     
