    var excelFile = Path.GetFullPath("C:\\ExcelSheet.xls");
    var excel = new Excel.Application();
    var workbook = excel.Workbooks.Open(excelFile);
    var sheet = (Excel.Worksheet)workbook.Worksheets.Item[1]; // 1 is the first item, this is NOT a zero-based collection
    sheet.Name = DateTime.Now.ToString("yyyyMMddHHmmss");
    workbook.Save();
    excel.Application.Workbooks.Close();
