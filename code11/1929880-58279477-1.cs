    public static int YourMethod()
    {
        return ExternalMethodAsync().Result;
    }
    public static async Task<string> ExternalMethodAsync()
    {
        Thread.Sleep(500); // Synchronous part
        await Task.Delay(500); // Asynchronous part
        return $"Time: {DateTime.Now:HH:mm:ss.fff}";
    }
