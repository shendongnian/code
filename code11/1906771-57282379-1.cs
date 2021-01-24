    public static TaskAggregator LogTasksAggregator = new TaskAggregator();
    public static void Log(string str)
    {
        var logTask = Console.Out.WriteLineAsync(str);
        LogTasksAggregator.Add(logTask);
    }
    // End of program
    LogTasksAggregator.CompleteAdding();
    bool completedInTime = LogTasksAggregator.Task.Wait(5000);
    if (!completedInTime)
    {
        Console.WriteLine("LogTasksAggregator timed out");
    }
