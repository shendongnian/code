    Task task = Task.Run(() => { });
    Task<Task> continuation1 = task.ContinueWith(async prev =>
    {
        Console.WriteLine("Continue with 1 start");
        await Task.Delay(1000);
        Console.WriteLine("Continue with 1 end");
    });
    Task continuation2 = continuation1.ContinueWith(prev =>
    {
        Console.WriteLine("Continue with 2 start");
    });
    await continuation2;
    Console.WriteLine($"task.IsCompleted: {task.IsCompleted}");
    Console.WriteLine($"continuation1.IsCompleted: {continuation1.IsCompleted}");
    Console.WriteLine($"continuation2.IsCompleted: {continuation2.IsCompleted}");
    Console.WriteLine($"continuation1.Unwrap().IsCompleted:" +
        $" {continuation1.Unwrap().IsCompleted}");
    await await continuation1;
