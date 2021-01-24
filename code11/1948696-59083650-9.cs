    static async void BarAsync()
    {
        Console.WriteLine("The start of FooMethod"); // synchronous
        await Task.Run(() => FooMethod());                //  asynchronous
        Console.WriteLine("The end of FooMethod");
    }
    static void FooMethod()
    {   
        Thread.Sleep(8000);
        Console.WriteLine("Hello World");
    }
