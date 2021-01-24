    DataTable dt = new DataTable();
    List<string> colList = new List<string>();
    // Loop through column collection 
    // Add all your columns to data table first
    foreach (ExcelReportColumn eachColumn in excelColumn)
    {
        dt.Columns.Add(eachColumn, typeof(string));
        colList.Add(eachColumn);
    }
    
    DataRow newRow;
    int currentCol = 0;
    // Then add your data rows
    foreach (ExcelReportCell excelCell in excelRow)
    {
        newRow = dt.NewRow();
        // Magic Method: You need to know the column name for the the current cell
        string columnName = colList[currentCol]; 
        newRow[columnName] = excelCell;
        dt.Rows.Add(newRow);
        currentCol++;
    }
