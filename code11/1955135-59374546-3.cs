    public static async Task Main()
    {
        if (await WaitFor(
            MyAsyncMethod(), 
            TimeSpan.FromSeconds(1),
            exception => Console.WriteLine("Exception: " + exception.Message))
        )
            Console.WriteLine("First await completed");
        else
            Console.WriteLine("First await didn't complete");
        Console.ReadLine();
    }
