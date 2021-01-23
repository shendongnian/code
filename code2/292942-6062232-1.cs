    public T ParseValue<T>(System.Data.SqlClient.SqlDataReader reader, string column)
    {
         T result = default(T);
         int index = reader.GetOrdinal(column);
         if (!reader.IsDBNull(index))
             result = (T)reader.GetValue(index);
    
         return result;
    }
