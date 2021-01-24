    DataTable dt = new DataTable();
    
    // Loop through column collection 
    // Add all your columns to data table first
    foreach (ExcelReportColumn eachColumn in excelColumn)
    {
        dt.Columns.Add(eachColumn, typeof(string));
    }
    
    DataRow newRow;
    // Then add your data rows
    foreach (ExcelReportCell excelCell in excelRow)
    {
        newRow = dt.NewRow();
        // Magic Method: You need to know the column name for the the current cell
        string columnName = GetColumnNameForCell(excelCell); 
        newRow[columnName] = excelCell;
        dt.Rows.Add(newRow);
    }
