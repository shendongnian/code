csharp
static async Task Main(string[] args)
    {
        try
        {
            await ProcessTask();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There was an exception: {ex.ToString()}");
        }
    }
