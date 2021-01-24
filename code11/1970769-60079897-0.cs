    var tasks = new Task<bool>[10];
    for (int i = 0; i < 10; i++)
    {
        var task = new Task<Task<bool>>(async () => await T());
        task.Start(); // Starts the outer task that creates the inner task
        tasks[i] = await task;
    }
    await Task.WhenAll(tasks);
    for (int i = 0; i < tasks.Length; i++)
    {
        Console.WriteLine($"Task {i} result = {await tasks[i]}");
    }
