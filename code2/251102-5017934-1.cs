     public T ParseValue<T>(System.Data.SqlClient.SqlDataReader reader, string column)
     {
         T result = default(T);
    
         if (!reader.IsDBNull(reader.GetOrdinal(column)))
             result = (T)reader.GetValue(reader.GetOrdinal(column));
    
         return result;
     }
