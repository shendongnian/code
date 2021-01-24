    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to start the timer");
        Console.ReadKey();
        Stopwatch sw = Stopwatch.StartNew();
        Console.WriteLine("Timer started. Press any key to stop");
        Console.ReadKey();
        sw.Stop();
        Console.WriteLine("The timer has stopped.");
        Console.WriteLine($"Elapsed time is: {sw.Elapsed.TotalSeconds} seconds.");
        Console.ReadLine();
    }
