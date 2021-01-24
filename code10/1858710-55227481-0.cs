    protected DataTable CopyColumn(DataTable sourceTable, string columnName)
    {
        DataTable result = new DataTable();
        result.Columns.Add(new DataColumn(columnName));
    
        foreach(DataRow sourceRow in sourceTable.Rows)
        {
             var destRow = result.NewRow();
             destRow[columnName] = sourceRow[columnName];
             result.Rows.Add(destRow);
        }
        return result;
    }
