        Excel.Application ExcelApp = new Excel.Application();
        Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(ResultsFilePath);
        ExcelApp.Visible = true;
        //Looping through all available sheets
        foreach (Excel.Worksheet ExcelWorksheet in ExcelWorkbook.Sheets)
        {                
            //Selecting the worksheet where we want to perform action
            ExcelWorksheet.Select(Type.Missing);
            ExcelWorksheet.Columns[1].NumberFormat = "@";
        }
        //saving excel file using Interop
        ExcelWorkbook.Save();
        //closing file and releasing resources
        ExcelWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
        Marshal.FinalReleaseComObject(ExcelWorkbook);
        ExcelApp.Quit();
        Marshal.FinalReleaseComObject(ExcelApp);
