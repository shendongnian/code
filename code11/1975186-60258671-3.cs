    int n = 0;
    string tmpColumnName = columnName;
    while (myGridView.Columns.Contains(tmpColumnName))
    {
      //Do something with column name index
      n++;
      tmpColumnName = columnName + n.ToString();
    }
    Result.GridViewDataTable.Columns[currCol].ColumnName = columnName;
