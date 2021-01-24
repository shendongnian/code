    static void Main(string[] args)
        {
            long completed = 0;
            Task.Run(() =>
            {
                while (completed < 100000)
                {
                    Console.WriteLine((completed * 100 / 100000) + "%");
                    Thread.Sleep(500);
                }
            });
            DateTime start = DateTime.Now;
            var output = Enumerable.Range(1, 100000)
                .AsParallel()
                .WithProgressReporting(()=>Interlocked.Increment(ref completed))
                .Select(v => { Thread.Sleep(1); return v * v; })
                .ToList();
            Console.WriteLine("Completed in: " + (DateTime.Now - start).TotalSeconds + " seconds");
            Console.ReadKey();
        }
