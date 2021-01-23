    private void DeleteCells(object sender, EventArgs e)
    {
        // create excel-instance:
        Excel.Application excel = new Excel.Application();
        // open the concrete file:
        Excel.Workbook excelWorkbook = excel.Workbooks.Open(@"D:\test.xls");
        // select worksheet. NOT zero-based!!:
        Excel._Worksheet excelWorkbookWorksheet = excelWorkbook.Sheets[1];
        // create a range:
        Excel.Range usedRange = excelWorkbookWorksheet.UsedRange;
        // iterate range
        foreach (Excel.Range r in usedRange)
        {
            // check condition:
            if (r.Value2 == 5.0F)
                // if match, delete and shift remaining cells up:
                r.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
        }
        // save changes (!!):
        excelWorkbook.Save();
        // cleanup:
        if (excel != null)
        {
            Process[] pProcess;
            pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
            pProcess[0].Kill();
        }
    }
