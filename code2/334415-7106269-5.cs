    public static IEnumerable<IDataRecord> Enumerate(this IDataReader reader)
    {
        while (reader.Read())
        {
            yield return reader;
        }
    }
