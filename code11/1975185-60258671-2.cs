    int n = 0;
    while (Result.GridViewDataTable.Columns.Contains(columnName))
    {
        //Do something with column name index
        n++;
        columnName = columnName + n.ToString();
    }
    Result.GridViewDataTable.Columns[currCol].ColumnName = columnName;
