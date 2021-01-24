    string return1 = string.Empty;
    string return2 = string.Empty;
    var tasks = new[]
    {
        Task.Factory.StartNew(() => return1 = "First return"),
        Task.Factory.StartNew(() => return2 = "Second return"),
    };
    Task.WaitAll(tasks);
    Console.WriteLine(return1); // First return
    Console.WriteLine(return2); // Second return
