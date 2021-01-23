    public static DateTime? ToNullableDateTime(this string date)
    {
        DateTime dateTime;
        return (DateTime.TryParse(date, out dateTime))
            ? (DateTime?)dateTime
            : null;
    }
