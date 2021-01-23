    using Microsoft.Office.Interop.Excel;
    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    Workbook workbook1 = excelApp.Workbooks.Open(filename, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
    Worksheet sheet1 = (Worksheet)workbook1.Sheets[1];
    Range excelRange = sheet1.UsedRange;
    for (int i = 1; i <= excelRange.Rows.Count; i++)
    {
        //do stuff.
    }
    
    workbook1.Close(false, filename, null);
    excelApp.Quit();
