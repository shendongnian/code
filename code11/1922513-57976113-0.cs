    private static async Task DoJob(CancellationToken ct)
    {
        var completedTask = await Task.WhenAny(Task.Delay(1000, ct));
        if (completedTask.IsFaulted)
        {
            Console.WriteLine("Error: " + completedTask.Exception.InnerException);
        }
        else if (completedTask.IsCanceled)
        {
            // Do nothing
        }
        else // Success
        {
            // Do nothing
        }
    }
