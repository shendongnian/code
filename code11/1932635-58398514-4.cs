    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to start the timer");
        Console.ReadKey();
        Stoper s1 = new Stoper();
        s1.Start();
        Console.WriteLine("Timer started. Press any key to stop");
        Console.ReadKey();
        s1.Stop();
        Console.WriteLine("The timer has stopped.");
        Console.WriteLine($"Elapsed time is: {s1.ElapsedTime.TotalSeconds} seconds.");
        Console.ReadLine();
    }
