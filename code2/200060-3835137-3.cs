    static DateTime Max(DateTime a, DateTime b)
    {
        return new DateTime(Math.Max(a.Ticks, b.Ticks));
    }
    static DateTime Min(DateTime a, DateTime b)
    {
        return new DateTime(Math.Min(a.Ticks, b.Ticks));
    }
