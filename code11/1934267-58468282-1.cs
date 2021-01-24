    public static IEnumerable<DateTime> GetNow()
    {
        while (true) { yield return DateTime.Now; }
    }
    public static async Task Main()
    {
        foreach(var now in GetNow())
        {
            Console.WriteLine(now);
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
This will fetch the current time one by one, each second.
20/10/2019 08:00:45
20/10/2019 08:00:46
20/10/2019 08:00:47
20/10/2019 08:00:48
20/10/2019 08:00:49
