    public static TimeSpan Average(TimeSpan first, TimeSpan second)
    {
        return TimeSpan.FromTicks((first + second).Ticks / 2);
    }
    public static string Average(string first, string second)
    {
        TimeSpan firstSpan = TimeSpan.Parse(first);
        TimeSpan secondSpan = TimeSpan.Parse(second);
        return Average(firstSpan, secondSpan).ToString();
    }
