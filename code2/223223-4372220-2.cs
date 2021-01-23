    var cache = new Cache<string, int>();
    Task<int> task = cache.GetAsync("Hello World", s => s.Length);
    // ... do something else ...
    task.Wait();
    Console.WriteLine(task.Result);
