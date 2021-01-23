    DataTable dataTable = new DataTable();
    
    int columnsCount = // Set the number of the table's columns here.
    
    for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
    {
        DataColumn dataColumn = new DataColumn();
        // Assign dataColumn properties' values here ..
        dataTable.Columns.Add(dataColumn);
    }
    
    int rowsCount = // Set the number of the table's rows here.
    
    for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
    {
        DataRow dataRow = new DataRow();
        dataRow["ColumnName"] = // Set the value here ..
        dataTable.Rows.Add(dataRow);        
    }
