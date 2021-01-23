    using Microsoft.Office.Interop.Excel;
    // init excel
    Application excelApplication = new Application();
    // ...
    // open book in any format
    Workbook workbook = excelApplication.Workbooks.Open("1.xls", XlUpdateLinks.xlUpdateLinksNever, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    // save in XlFileFormat.xlExcel12 format which is XLSB
    workbook.SaveAs("1.xlsb", XlFileFormat.xlExcel12, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    // close workbook
    workbook.Close(false, Type.Missing, Type.Missing);
    
    // ...
    // shutdown excel
    excelApplication.Quit();
