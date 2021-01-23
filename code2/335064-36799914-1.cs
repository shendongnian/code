    public T GetColumnValue<T>(DataRow row, string columnName)
      {
            T value = default(T);
            if (row.Table.Columns.Contains(columnName) && row[columnName] != null && !String.IsNullOrWhiteSpace(row[columnName].ToString()))
            {
                value = (T)Convert.ChangeType(row[columnName].ToString(), typeof(T));
            }
            
            return value;
      }
