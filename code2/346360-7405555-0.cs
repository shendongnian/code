    var xl = new Excel.Application();
    xl.Visible = true;
    var wb = (Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
    var sheet = (Excel._Worksheet)wb.ActiveSheet;
    sheet.Cells[6, 6] = "6";
