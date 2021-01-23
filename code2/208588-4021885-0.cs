    public static class IDataReaderExtensions
    {
        public static int? GetNullableInt32(this IDataReader r, string columnName)
        {
            int? myVal = r.IsDBNull(r.GetOrdinal(columnName)) 
                            ? (int?) null : 
                            r.GetInt32(r.GetOrdinal(columnName));
            return myVal;
        }
    }
