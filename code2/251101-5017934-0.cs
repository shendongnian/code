    public T ParseValue<T>(SqlDataReader reader, string column)
    {
        T result = (T)Activator.CreateInstance(typeof(T));
        if (!reader.IsDBNull(column))
            result = (T)reader.GetValue(reader.GetOrdinal(column));
        return result;
    }
