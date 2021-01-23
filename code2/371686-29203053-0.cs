    public static class SqlDataReaderExtensions
    {
        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string fieldName)
        {
            int x = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(x) ? (DateTime?) null : reader.GetDateTime(x);
        }
    }
