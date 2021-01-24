    var xlApp = (Microsoft.Office.Interop.Excel.Application)ExcelDna.Integration.ExcelDnaUtil.Application;
    xlApp.WorkbookOpen += XlAppOnWorkbookOpen;
    private void XlAppOnWorkbookOpen(Microsoft.Office.Interop.Excel.Workbook wb)
    {
        // ...
    }
