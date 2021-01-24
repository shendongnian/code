    static async Task Main(string[] args)
    {
        var task = simpleAsync();
        Console.WriteLine("Doing other things...");
        await task;
    }
    static async Task simpleAsync()
    {
        int i = await jobAsync();
        Console.WriteLine("Async done. Result: " + i.ToString());
    }
