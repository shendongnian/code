    int v = row.Get<int>("vvv");               // throws if column is null
    int? w = row.Get<int?>("www");             // set to null if column is null
    int x = row.Get<int?>("xxx") ?? -1;        // set to -1 if column is null
    string y = row.Get<string>("yyy");         // set to null if column is null
    string z = row.Get<string>("zzz") ?? ""    // set to "" if column is null
    // ...
    public static T Get<T>(this DataRow source, string columnName)
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
