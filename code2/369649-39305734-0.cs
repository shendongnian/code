    public static T GetFieldValueOrDefaultIfNull<T>(this SqlDataReader reader, string indexName)
    {
        if (reader.IsDBNull(reader.GetOrdinal(indexName)))
        {
            return default(T); // returns the default value for the type
        }
        else
        {
            return reader.GetFieldValue<T>(reader.GetOrdinal(indexName));
        }
    }
