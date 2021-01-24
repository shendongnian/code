    var throttler = new Throttler<string>(20, 0, 4000);
    var keys = new string[] { "Mike", "John", "Sarah", "Matt", "John", "Jacob",
        "John", "Amy" };
    var tasks = new List<Task>();
    foreach (var key in keys)
    {
        tasks.Add(throttler.Execute(key, () => MockHttpCall(key)));
    }
    Task.WaitAll(tasks.ToArray());
    async Task<int> MockHttpCall(string id)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} HTTP call for " + id);
        await Task.Delay(300);
        return 0;
    }
