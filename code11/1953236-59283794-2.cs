    void Main()
    {
        Test().GetAwaiter().GetResult();
    }
    
    private async Task<bool> CheckEmpty(string input)
    {
        await Task.Delay(200);
        return String.IsNullOrEmpty(input);
    }
    
    private async Task Test()
    {
        var list = new List<string>
        {
            "1",
            null,
            "2",
            ""
        };
    
        var stopwatch = new Stopwatch();
        stopwatch.Start();
    
        // This takes aprox 4 * 200ms == 800ms to complete.
        foreach (var itm in list)
        {
            Console.WriteLine(await CheckEmpty(itm));
        }
        
        Console.WriteLine(stopwatch.Elapsed);
        Console.WriteLine();
        stopwatch.Reset();
        stopwatch.Start();
    
        // This takes aprox 200ms to complete.
        var tasks = list.Select(itm => CheckEmpty(itm));
        var results = await Task.WhenAll(tasks); // Runs all at once.
        Console.WriteLine(String.Join(Environment.NewLine, results));
        Console.WriteLine(stopwatch.Elapsed);
    }
