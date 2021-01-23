    string strFileName = "D:\\test1.xlsx";
    Microsoft.Office.Interop.Excel.Application ExcelObj = null;
    ExcelObj = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
    Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range("A11", "G21"); // Your requied range here
    foreach (Microsoft.Office.Interop.Excel.Range cell in range.Cells)
    {
       if(cell.TextToString()=="Yes")
        {
        }
       if(cell.TextToString()=="No")
        {
        }
    }
