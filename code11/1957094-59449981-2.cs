    var consumer = Task.Run(async () =>
    {
        while (await block.OutputAvailableAsync())
        {
            while (block.TryReceive(out var task))
            {
                Console.WriteLine($"Task Completed: {task.Status}");
            }
        }
    });
