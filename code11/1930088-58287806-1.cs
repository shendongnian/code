    public static async Task DoWork(CancellationToken cancellationToken)
    {
        while (true)
        {
            await Console.Out.WriteLineAsync("Working...");
            await Task.Delay(1500, cancellationToken);
        }
    }
