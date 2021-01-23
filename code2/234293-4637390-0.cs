    // Convenience method to obtain a field within a row (as a double type) 
    public static T Get<T>(this DataRow row, string field) {
        if (row != null && row.Table.Columns.Contains(field))
        {
            object value = row[field];
            if (value != null && value != DBNull.Value)
                return (T)value;
        }
        return default(T);
    }
