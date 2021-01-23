    using Excel = Microsoft.Office.Interop.Excel;
    
    public static object GetCellValue(
           string filename, string sheet, int row, int column)
    {
        Excel.Application excel = new Excel.Application();
        Excel.Workbook wb = excel.Open(filename);
        Excel.Worksheet sh = wb.Sheets[sheet];
        object ret = sh.Cells[row, column].Value2;
        wb.Close();
        excel.Quit();
    }
