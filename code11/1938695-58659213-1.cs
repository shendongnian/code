    private static void <Main>()
    {
        Program.Main().GetAwaiter().GetResult();
    }
    public static async Task Main()
    {
        Console.WriteLine("Awaiting");
        await Task.Delay(2000);
        Console.WriteLine("Awaited");
    }
