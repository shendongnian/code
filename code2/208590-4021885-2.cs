    public static class IDataReaderExtensions
    {
        public static int? GetNullableInt32(this IDataReader r, string columnName)
        {
            int ordinal = r.GetOrdinal(columnName);
            int? myVal = r.IsDBNull(ordinal) 
                            ? (int?) null : 
                            r.GetInt32(ordinal);
            return myVal;
        }
    }
