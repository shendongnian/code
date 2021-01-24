    public static void Main()
    {
        TimeSpan[] hours = new[] {
            new TimeSpan(10, 35, 50),
            new TimeSpan(10, 36, 48),
            new TimeSpan(10, 41, 48),
            new TimeSpan(10, 47, 58),
            new TimeSpan(10, 49, 14),
            new TimeSpan(11, 22, 15),
            new TimeSpan(11, 24, 18),
            new TimeSpan(11, 25, 25),
        };
        foreach (var group in GroupItemsWithin(hours, TimeSpan.FromMinutes(5)))
        {
            Console.WriteLine(string.Join(", ", group));
        }
    }
