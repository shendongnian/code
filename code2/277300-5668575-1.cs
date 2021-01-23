    public static class SqlDataReaderExtensions
    {
        public static DateTime GetDateTimeValue(this SqlDataReader reader, 
            string fieldName)
        {
            return GetDateTimeValue(reader, fieldName, DateTime.MinValue);
        }
    
        public static DateTime GetDateTimeValue(this SqlDataReader reader, 
            string fieldName, DateTime defaultValue)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(ordinal) 
                ? reader.GetDateTime(ordinal) 
                : defaultValue;
        }
    }
