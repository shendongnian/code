    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application excel = new Excel.Application();
    Excel.Workbook wb = excel.Workbooks.Open("filename");
    Excel.Worksheet sh = wb.Sheets[1]; // or wb.Sheets["name"]
    int row = 2;
    foreach (string item in array)
    {
        sh.Cells[row,col].Value2 = item;
        row++;
    }
    wb.Save();
    wb.Close();
    excel.Quit();
