    class Program
    {
        static void Main(string[] args)
        {
            SystemClock oncePerSecond = new SystemClock();
            VariableSystemClock oncePerInterval = new VariableSystemClock(TimeSpan.FromSeconds(2));
            Console.WriteLine("Start:");
            Console.WriteLine("  oncePerSecond:   {0}", oncePerSecond.getSystemTime());
            Console.WriteLine("  oncePerInterval: {0}", oncePerInterval.getSystemTime());
            Console.WriteLine();
            for (Int32 i = 0; i < 10; i++)
            {
                // sleep three seconds
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                // display output
                Console.WriteLine("Interval {0}:", i);
                Console.WriteLine("  oncePerSecond:   {0}", oncePerSecond.getSystemTime());
                Console.WriteLine("  oncePerInterval: {0}", oncePerInterval.getSystemTime());
                Console.WriteLine();
            }
            Console.WriteLine("End:");
            Console.WriteLine("  oncePerSecond:   {0}", oncePerSecond.getSystemTime());
            Console.WriteLine("  oncePerInterval: {0}", oncePerInterval.getSystemTime());
            Console.WriteLine();
        }
    }
