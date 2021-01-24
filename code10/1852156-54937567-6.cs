    static async Task Main(string[] args)
    {     
        var task = SomeAsyncCode();
        Console.WriteLine("Run First");
        await Task.WhenAll(task);
    }
