    public static class DataReaderExtensions
    {
        public static TResult Get<TResult>(this IDataReader reader, string name)
        {
            return reader.Get<TResult>(reader.GetOrdinal(name));
        }
        public static TResult Get<TResult>(this IDataReader reader, int c)
        {
            return ConvertTo<TResult>.From(reader[c]);
        }
     }
