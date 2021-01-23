    int w = row.GetValue<int>("www");           // throws if column is null
    int? x = row.GetValue<int?>("xxx");         // set to null if column is null
    int y = row.GetValue<int?>("yyy") ?? -1;    // set to -1 if column is null
    string z = row.GetValue<string>("zzz");     // set to null if column is null
    // ...
    public static T GetValue<T>(this DataRow source, string columnName)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (columnName == null)
            throw new ArgumentNullException("columnName");
        if (columnName.Length < 1)
            throw new ArgumentException("Name cannot be empty.", "columnName");
        if (source.IsNull(columnName))
        {
            T defaultValue = default(T);
            if (defaultValue == null)
                return defaultValue;
        }
        // throws if the column is null and T is a non-nullable value type
        return (T)source[columnName];
    }
