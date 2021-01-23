    static void Main()
    {
        Thread thread = new Thread(MoreStuff);
        thread.IsBackground = false;
        thread.Start();
        Console.WriteLine("Main thread exiting");
    }
    static void MoreStuff()
    {
        Console.WriteLine("Second thread starting");
        Thread.Sleep(5000); // simulate work
        Console.WriteLine("Second thread exiting");
    }
