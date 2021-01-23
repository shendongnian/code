    public static void Insert<T>(this OracleBulkCopy copy, IEnumerable<T> entities)
        where T : class
    {
        var properties = typeof(T).GetProperties();
        var columnNames = new List<string>();
        var columnPropertyNames = new List<string>();
        foreach (var propertyInfo in properties)
        {
            var attribute = Attribute.GetCustomAttribute(propertyInfo, typeof(ColumnAttribute)) as ColumnAttribute;
            if (attribute != null)
            {
                columnNames.Add(attribute.Name);
                columnPropertyNames.Add(propertyInfo.Name);
            }
        }
    
        copy.ColumnMappings.Clear();
        foreach (var columnName in columnNames)
        {
            copy.ColumnMappings.Add(columnName, columnName);
        }
    
        var table = new DataTable(copy.DestinationTableName);
    
        foreach (var columnMapping in copy.ColumnMappings)
        {
            table.Columns.Add(((SqlBulkCopyColumnMapping)columnMapping).DestinationColumn);
        }
    
        foreach (var entity in entities)
        {
            var row = table.NewRow();
            for (var i = 0; i < columnNames.Count; i++)
            {
                var value = typeof (T).GetProperty(columnPropertyNames[i]).GetValue(entity, null);
                if (value is DateTime)
                    value = new OracleDate((DateTime) value);
                row[columnNames[i]] = value;
            }
    
            table.Rows.Add(row);
        }
    
        copy.WriteToServer(table);
    }
