    var xl = new Microsoft.Office.Interop.Excel.Application();
    var b = xl.Workbooks.Open("C:\\Junk\\Junk.xlsx");
    Microsoft.Office.Interop.Excel.Worksheet s = b.Worksheets[1]; //1-based
    var r = s.Range["A1", "E4"];
    int sum = 0;
    for (var row = 1; row <= 4; row += 2)
    {
        sum += r.Value2[row, 1]; //also 1-based
    }            
    xl.Quit();
