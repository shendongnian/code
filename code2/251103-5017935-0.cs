    int v = dr.GetValue<int>("vvv");             // throws if column is null
    int? w = dr.GetValue<int?>("www");           // set to null if column is null
    int x = dr.GetValue<int?>("xxx") ?? -1;      // set to -1 if column is null
    string y = dr.GetValue<string>("yyy");       // set to null if column is null
    string z = dr.GetValue<string>("zzz") ?? ""  // set to "" if column is null
    // ...
    public static T GetValue<T>(this IDataRecord source, string fieldName)
    {
        return source.GetValue<T>(source.GetOrdinal(fieldName));
    }
    public static T GetValue<T>(this IDataRecord source, int fieldIndex)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (fieldIndex < 0)
            throw new ArgumentOutOfRangeException("fieldIndex", fieldIndex,
                                                  "Index cannot be negative.");
        if (source.IsDBNull(fieldIndex))
        {
            T defaultValue = default(T);
            if (defaultValue == null)
                return defaultValue;
        }
        // throws if the field is null and T is a non-nullable value type
        return (T)source.GetValue(fieldIndex);
    }
