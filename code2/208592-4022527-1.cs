    int? myVal = r.GetValue<int?>("colName");
    // ...
    public static class DataReaderExtensions
    {
        public static T GetValue<T>(this IDataReader dr, string columnName)
        {
            return dr.GetValue<T>(dr.GetOrdinal(columnName));
        }
        public static T GetValue<T>(this IDataReader dr, int columnOrdinal)
        {
            // does the column contain null?
            if (dr.IsDBNull(columnOrdinal))
            {
                // is T either a ref type or a nullable value type?
                Type t = typeof(T);
                if (!t.IsValueType || (Nullable.GetUnderlyingType(t) != null))
                {
                    // return null
                    return default(T);
                }
            }
            // get the column value, cast it as T and return it
            // this will throw if the value isn't convertible/unboxable to T
            return (T)dr.GetValue(columnOrdinal);
       }
    }
