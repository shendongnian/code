    async static Task Main(string[] args)
    {
        try
        {
            await TryExecuteAsync(AsyncFunction);
            Console.WriteLine("Finished without unhandled exception.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to execute: " + ex.Message);
        }
    }
