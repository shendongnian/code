        Application ExcelObj = new Application();
        Workbook WB = ExcelObj.Workbooks.Open(fileName,
            0, true, 5, "", "", true, XlPlatform.xlWindows, "\t",
            false, false, 0, true, false, false);
        Sheets sheets = WB.Worksheets;
        Worksheet WS = (Worksheet)sheets.get_Item(1);
        Range excelRange = WS.UsedRange;
            ... (DO STUFF?)
  
            // Get rid of everything - close Excel
            while (Marshal.ReleaseComObject(WB) > 0) { }
            WB = null;
            while (Marshal.ReleaseComObject(sheets) > 0) { }
            sheets = null;
            while (Marshal.ReleaseComObject(WS) > 0) { }
            WS = null;
            while (Marshal.ReleaseComObject(excelRange) > 0) { }
            excelRange = null;
            GC();
            ExcelObj.Quit();
            while (Marshal.ReleaseComObject(ExcelObj) > 0) { }
            ExcelObj = null;
            GC();
        public static void GC()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
