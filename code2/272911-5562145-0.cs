    public static T GetValue<T>(this IDataReader reader, string field, T defaultValue)
    {
        int index = reader.GetOrdinal(field);
        if (reader.IsDBNull(index)) {
            return defaultValue;
        } else {
            return (T)(reader[name]);
        }
    }
