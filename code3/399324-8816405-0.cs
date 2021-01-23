    static void Test()
    {
        // Initialize Api COMObject Support
        LateBindingApi.Core.Factory.Initialize();
        
        // start excel and turn off msg boxes
        Excel.Application excelApplication = new Excel.Application();
        excelApplication.DisplayAlerts = false;
        // add a new workbook
        Excel.Workbook workBook = excelApplication.Workbooks.Add();
        Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1]; 
        worksheet.get_Range("A1").Value = "XXX";
        
        // save the book 
        string fileExtension = GetDefaultExtension(excelApplication);
        string workbookFile = string.Format("{0}\\Example01{1}", 
                           Application.StartupPath, fileExtension);
        workBook.SaveAs(workbookFile, Missing.Value, Missing.Value, Missing.Value,
                   Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive);
              
        // close excel and dispose reference
        excelApplication.Quit();
        excelApplication.Dispose();
    }
