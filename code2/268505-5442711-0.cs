    class Program
    {
        static void Main()
        {
            var ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine("{0} Mb", ramCounter.NextValue());
        }
    }
