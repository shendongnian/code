    static async Task Main(string[] args)
    {
        var task1 = Helper1.GetStuff();
        var task2 = Helper2.GetStuff();
        
        await Task.WhenAll(task1, task2);
    
        Console.WriteLine(task1.Result);
        Console.WriteLine(task2.Result);
    }
