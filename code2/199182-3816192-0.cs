    private static DateTime RoundToSecond(DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, dt.Day,
                            dt.Hour, dt.Minute, dt.Second);
    }
    ...
    if (RoundToSecond(dt1) == RoundToSecond(dt2))
    {
        ...
    }
