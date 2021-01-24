    static void Main(string[] args)
    {
        TestRoundingForHourAfter(DateTime.Parse("10 AM"));
        TestRoundingForHourAfter(DateTime.Parse("10 AM").AddTicks(123456789));
    }
    static void TestRoundingForHourAfter(DateTime baseTime)
    {
        foreach (DateTime input in Enumerable.Range(0, 60).Select(minutes => baseTime + TimeSpan.FromMinutes(minutes)))
        {
            DateTime output = RoundDown(input, TimeSpan.FromMinutes(10));
            Console.WriteLine($"{input:hh:mm:ss.fffffff} rounds to {output:hh:mm:ss.fffffff}");
        }
    }
    public static DateTime RoundDown(DateTime dt, TimeSpan d)
    {
        var delta = dt.Ticks % d.Ticks;
        return new DateTime(dt.Ticks - delta, dt.Kind);
    }
