    public static DateTime SqlDateTimeSet(object drValue)
    {
        DateTime? dt;
        dt = drValue as DateTime?;
        return dt.GetValueOrDefault();
    }
