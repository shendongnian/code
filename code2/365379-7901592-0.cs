    static void Main(string[] args)
    {
        Console.WriteLine("A");
        // in .NET, Main() must be 'void', and the program terminates after
        // Main() returns. Thus we have to do an old fashioned Wait() here.
        OuterAsync().Wait();
        Console.WriteLine("K");
        Console.ReadKey();
    }
    static async Task OuterAsync()
    {
        Console.WriteLine("B");
        await MiddleAsync();
        Console.WriteLine("J");
    }
    static async Task MiddleAsync()
    {
        Console.WriteLine("C");
        await InnerAsync();
        Console.WriteLine("I");
    }
    static async Task InnerAsync()
    {
        Console.WriteLine("D");
        await DoSomething();
        Console.WriteLine("H");
    }
    private static Task DoSomething()
    {
        Console.WriteLine("E");
        return Task.Run(() =>
            {
                Console.WriteLine("F");
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(100);
                }
                Console.WriteLine("G");
            });
    }
