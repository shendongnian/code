    ExcelPackage pck = new ExcelPackage();
    foreach (DataTable table in ds.Tables)
    {
    	var ws = pck.Workbook.Worksheets.Add(table.TableName);
    	ws.Cells["A1"].LoadFromDataTable(table, true);
    }
    
    var fi = new FileInfo(@"c:\temp\MyExcelDataSet.xlsx");
    if (fi.Exists)
    {
    	fi.Delete();
    }
    pck.SaveAs(fi);
