    Excel.Application excel = new Excel.Application();
    Excel.Workbook workbook = excel.Workbooks.Add(Missing.Value) as Excel.Workbook;
    ...
    object filename = excel.GetSaveAsFilename("DefaultName.xls", 
        "Excel 2000-2003 Workbook (*.xls), *.xls", Missing.Value, 
        Missing.Value, Missing.Value);
    if (!(filename is bool))
    {
        workbook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value,
            Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value);
            excel.Quit();
    }
