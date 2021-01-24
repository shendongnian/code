    static async Task Main(string[] args)
    {
        var task1 = Task.Run(RunAsync);
        var task2 = Task.Run(RunAsync);
        var task3 = Task.Run(RunAsync);
        await Task.WhenAll(task1, task2, task3);
        Console.ReadKey();
    }
    static async Task RunAsync()
    {
        Task tt1 = WebServiceProcess("Task1");
        Task tt2 = WebServiceProcess("Task2");
        Task tt3 = WebServiceProcess("Task3");
        await Task.WhenAll(tt1, tt2, tt3);
    }
