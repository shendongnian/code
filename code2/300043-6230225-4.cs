    static void Main(string[] args)
    {
        var clockIn = new DateTime(2011, 5, 25, 13, 40, 56);
        var clockOut = new DateTime(2011, 5, 25, 18, 22, 12);
        var hours = GetWorkingHourIntervals(clockIn, clockOut);
        foreach (var h in hours)
            Console.WriteLine(h);
        Console.ReadLine();
    }
