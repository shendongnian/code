    static void Main(String[] args)
    {
        Console.WriteLine("Press any key to prevent exit...");
        var tHold = Task.Run(() => Console.ReadKey(true));
        // ... do your console app activity ...
        if (tHold.IsCompleted)
        {
    #if false   // For the 'hold' state, you can simply halt forever...
            Console.WriteLine("Holding.");
            Thread.Sleep(Timeout.Infinite);
    #else                            // ...or allow continuing to exit
            while (Console.KeyAvailable)
                Console.ReadKey(true);     // flush/consume any extras
            Console.WriteLine("Holding. Press 'Esc' to exit.");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                ;
    #endif
        }
    }
