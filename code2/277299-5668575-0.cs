    private static DateTime GetDateTimeValue(SqlDataReader reader, string fieldName)
    {
        int ordinal = reader.GetOrdinal(fieldName);
        return reader.IsDBNull(ordinal) ? reader.GetDateTime(ordinal) : DateTime.MinValue;
    }
