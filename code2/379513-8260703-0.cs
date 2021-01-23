    ExcelPackage pck = new ExcelPackage();
    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
    ws.Cells["A1"].LoadFromDataTable(dataTable, true);
    FileStream aFile = new FileStream("c:\\data\\excelfile.xls", FileMode.Create);
    byte[] byData = pck.GetAsByteArray();
    aFile.Seek(0, SeekOrigin.Begin);
    aFile.Write(byData, 0, byData.Length);
    aFile.Close();
