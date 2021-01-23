    var hoursMap1 = dataTable1.Rows.Cast<DataRow>().ToDictionary(row => row[0]);
    var hoursMap2 = dataTable2.Rows.Cast<DataRow>().ToDictionary(row => row[0]);
    
    var resultTable = new DataTable();
    
    // Clone the column from table 1
    for (int i = 0; i < dataTable1.Columns.Count; i++)
    {
      var column = dataTable1.Columns[i];
      resultTable.Columns.Add(column.ColumnName, column.ColumnType);
    }
    
    foreach (var entry in hoursMap1)
    {
      int hours = entry.Key;
      DataRow row1 = entry.Value;
      DataRow row2 = null;
      if (!hoursMap2.TryGetValue(hours, out row2))
      {
        // Hours in table 1 but not table 2, handle error
      }
    
      var fields = new object[resultTable.Columns.Count];
      int fieldIndex = 0;
      fields[fieldIndex++] = hours;
    
      for (int i = 1; i < row1.ItemsArray.Length; i++)
      {
        var field1 = row1.ItemsArray[i];
        var field2 = row2.ItemsArray[i];
        var newField = field1 ?? field2;
        if (newField == null)
        {
          // Field neither in table 1 or table 2, handle error
        }
    
        fields[fieldIndex++] = newField;
      }
    
      resultTable.Rows.Add(fields);
    }
