    private static Dictionary<DayOfWeek, List<DaysOfWeek>> Maps { get; set; }
    
    static void Main(string[] args)
    {
        Maps = CreateMaps();
    
        var date = new DateTime(2011, 9, 29);
    
        var mask = DaysOfWeek.Wednesday | DaysOfWeek.Friday;
    
        var sw = Stopwatch.StartNew();
    
        for (int i = 0; i < 10000; i++)
        {
            GetNextDay(date, mask);
        }
    
        sw.Stop();
    
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
    
    private static DaysOfWeek GetNextDay(DateTime date, DaysOfWeek mask)
    {
        return Maps[date.DayOfWeek].First(dow => mask.HasFlag(dow));
    }
