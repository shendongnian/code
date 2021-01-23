    using Excel = Microsoft.Office.Interop.Excel;
    
    ...
    
    var excel = new Excel.Application();
    var wb = excel.Workbooks.Add();
    var sheet = (Excel.Worksheet)wb.Sheets[1];
    ((Excel.Range)sheet.Cells[3, 4]).Style = wb.Styles["Currency"];
