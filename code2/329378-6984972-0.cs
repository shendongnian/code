    class Program
    {
        private const int MaxInstanceCount = 2;
        private static readonly Semaphore Semaphore = new Semaphore(MaxInstanceCount, MaxInstanceCount, "CanRunTwice");
        static void Main(string[] args)
        {            
            if (Semaphore.WaitOne(1000))
            {
                try
                {
                    Console.WriteLine("Program is running");
                    Console.ReadLine();
                }
                finally
                {
                    Semaphore.Release();
                }
            }
            else
            {
                Console.WriteLine("I cannot run, too many instances are already running");
                Console.ReadLine();
            }
        }
    }
