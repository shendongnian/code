    class Program {
        static void Main(string[] args) {
            Process currentProcess = Process.GetCurrentProcess();
            for (int i = 0; i < 10; i++) {
                var t = new Task(() => DoMemoryHog(20000000));
                t.Start();
                t.Wait();
                t.Dispose();
                t = null;
                GC.Collect();
                Console.WriteLine("Done" +i);
                Console.WriteLine("Memory: " + GC.GetTotalMemory(false));
                Console.WriteLine("Paged: " + currentProcess.PagedMemorySize64);
                Console.WriteLine("-------------------------");
            }
            Console.ReadLine();
        }
        static void DoMemoryHog(int n) {
            ConcurrentBag<double> results = new ConcurrentBag<double>();
            Parallel.For(0, n, (i) =>
            {
                results.Add(Math.Sqrt(i.GetHashCode()));
            });
        }
    }
