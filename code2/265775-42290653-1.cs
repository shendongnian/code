     // Let's fix tons of mapping issues by
     // Setting the column mapping in SqlBulkCopy instance:
     foreach (DataColumn dataColumn in _dataTable.Columns)
     {
         bulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
      }
