    public static DateTime ToDateTime(string value)
    {
        if (value == null)
        {
            return new DateTime(0L);
        }
        return DateTime.Parse(value, CultureInfo.CurrentCulture);
    }
