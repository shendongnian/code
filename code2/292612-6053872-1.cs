    using MSExcel = Microsoft.Office.Interop.Excel;
    private MSExcel._Application excel;
    private MSExcel._Workbook workbook;
    private MSExcel._Worksheet worksheet;
    private MSExcel.Sheets sheet;
    Excelapp.DisplayAlerts = false;
    ((Excel.Worksheet)workBook.Worksheets[3]).Delete();
    Excelapp.DisplayAlerts = true;
