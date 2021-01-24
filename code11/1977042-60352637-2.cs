    public static DateTime GetDateTime(this DbDataReader reader, int columnNumber, string format) {
        string date = reader.GetString(columnNumber);
        DateTime dateTime = DateTime.ParseExact(date, format, null);
        return dateTime;
    }
