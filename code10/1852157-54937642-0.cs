    static void Main(string[] args)
    {
        // Call SomeAsyncCode() somehow
        SomeAsyncCode();
        Console.WriteLine("Run First");
        Console.ReadKey(); // you need this to prevent app from closing
    }
    private static async void SomeAsyncCode()
    {
        // Use await here!
        await Task.Delay(5000);
        Console.WriteLine("Run Last");
        // Other async goodness...
    }
