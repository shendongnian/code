    private async Task Solution1(string alertTime, string sound, int duration)
    {
        Console.WriteLine("Starting...");
    
        await Task.Delay(2000).ContinueWith(x =>
        {
            Console.WriteLine("Done");
        });
    
        Console.WriteLine("Done");
    }
