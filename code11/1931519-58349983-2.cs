    private DataTable fixDatatableType(DataTable input) {
    
     List<DataColumn> overwriteColumnIndex = new List<DataColumn>();
     List<string> addedColumns = new List<string>();
    
     for (int i = 0; i < input.Columns.Count; i++)
     {
      if (input.Columns[i].DataType == typeof(byte[])) {
          overwriteColumnIndex.Add(input.Columns[i]);
          string newColumnName = input.Columns[i].ColumnName + "_str";
          addedColumns.Add(newColumnName);
          DataColumn dataColumn = new DataColumn(newColumnName, typeof(string));
          input.Columns.Add(dataColumn);
      }
     }
    
     if (overwriteColumnIndex.Count != 0) {
      for (int z = 0; z < input.Rows.Count; z++)
      {
       DataRow row = input.Rows[z];
       for (int m = 0; m < overwriteColumnIndex.Count; m++)
       {
        if (row[overwriteColumnIndex[m]] != DBNull.Value) {
         row[addedColumns[m]] = 
         ByteArrayToHexString((byte[])row[overwriteColumnIndex[m]]);
        }
       }
      }
     }
     return input;
    }
