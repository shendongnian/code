    private bool TryGetOpenWorkbook(out Excel.Workbook workbook)
    {
    bool workbookFound = false;
    workbook = null;
    foreach (Process excelProcesses in Process.GetProcessesByName("EXCEL"))
    {
        Excel.Application excelApp = excelProcesses.AsExcelApp();
        foreach (Excel.Workbook wb in excelApp.Workbooks)
        {
            if (wb.Name.Equals(_workbookName))
            {
                workbook = wb;
                workbookFound = true;
            }
        }
        // Release Process
        excelApp.ReleaseComObject();
        excelProcesses.ReleaseComObject();
    }
    return workbookFound;
    }
