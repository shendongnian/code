    using OfficeOpenXml.Table;
    ExcelWorksheet ws = excel.Workbook.Worksheets[1];
    //create a range for the table
    ExcelRange range = ws.Cells[1, 1, ws.Dimension.End.Row, ws.Dimension.End.Column];
    
    //add a table to the range
    ExcelTable tab = ws.Tables.Add(range, "Table1");
    
    //format the table
    tab.TableStyle = TableStyles.Medium2;
