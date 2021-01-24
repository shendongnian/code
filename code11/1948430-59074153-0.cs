    static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();
            Console.WriteLine("Waiting for async to finish {0}", stopwatch.Elapsed);
            dosomething(stopwatch).Wait();
            Console.WriteLine("After wait {0}", stopwatch.Elapsed);
            // Stop timing.
            stopwatch.Stop();
            // Write result.
            Console.ReadLine();
        }
        public static async Task dosomething(Stopwatch stopwatch)
        {
            Console.WriteLine("Started async", stopwatch.Elapsed);
            await Task.Delay(6000);
            Console.WriteLine("Ended async", stopwatch.Elapsed);
        }
