    static void Main(string[] args)
    {
        var holidays = new List<DateTime>()
        {
            new DateTime(2019,05,03),
            new DateTime(2019,05,04),
            new DateTime(2019,05,06),
            new DateTime(2019,05,10),
        };
        int tatPeriod = 5;
        var assignDate = new DateTime(2019, 05, 01);
        var dueDate = Enumerable.Range(0, tatPeriod + holidays.Count)
                                .Select(offset => assignDate.AddDays(offset))
                                .Except(holidays)
                                .ElementAt(tatPeriod - 1);
        Console.WriteLine(dueDate);
        Console.Read();
    }
