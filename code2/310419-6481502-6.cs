    static void Main()
    {
        var are = new AutoResetEvent(false);
    
        new Thread(
            () =>
            {
                while (true)
                {
                    are.WaitOne();
                    Console.WriteLine("go");
                    Thread.Sleep(2000);
                }
            }).Start();
    
        while (true)
        {
            are.Set();
            Console.WriteLine("pulse");
            Thread.Sleep(1000);
        }
    
    }
