    DataTable dt = new DataTable();
    
    // Add all your columns to data table first
    foreach (ExcelReportColumn eachColumn in excelRowColumn)
    {
        dt.Columns.Add(eachColumn, typeof(string));
    }
    
    DataRow newRow;
    // Then add your data rows
    foreach (ExcelReportCell excelCell in excelRow)
    {
        newRow = dt.NewRow();
        string columnName = GetColumnNameForCell(excelCell); // You need to know the column name for the the current cell
        newRow[columnName] = excelCell;
        sampleDataTable.Rows.Add(sampleDataRow);
    }
