        private const int DataSize = 1000;
        private const string TestInt = "1";
        static void Main(string[] args)
        {
    #if DEBUG
            Console.Write("DEBUG code, ");
    #else
            Console.Write("RELEASE code, ");
    #endif
            Console.Write(System.Diagnostics.Debugger.IsAttached ? "Debugger attached. " : "no debugger. ");
            Console.WriteLine($"{DataSize} of \"{TestInt}\"");
            var seedData = new List<string>();
            seedData.AddRange(Enumerable.Repeat(TestInt, DataSize));
            var stopWatch = new System.Diagnostics.Stopwatch();
            // Handled
            stopWatch.Restart();
            var exceptions = new List<Exception>();
            foreach (var item in seedData)
            {
                try
                {
                    var x = int.Parse(item);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            var elapsed = stopWatch.Elapsed;
            Console.WriteLine($"Handled {elapsed}.");
            // Swallowed
            stopWatch.Restart();
            foreach (var item in seedData)
            {
                try
                {
                    var x = int.Parse(item);
                }
                catch (Exception ex)
                {
                    
                }
            }
            elapsed = stopWatch.Elapsed;
            Console.WriteLine($"Swallowed {elapsed}.");
            // But I would do this task using TryParse()
            stopWatch.Restart();
            var failedStrings = new List<string>();
            foreach (var item in seedData)
            {
                int x;
                if (!int.TryParse(item, out x))
                    failedStrings.Add(item);
            }
            elapsed = stopWatch.Elapsed;
            Console.WriteLine($"Tryparse {elapsed}.");
            Console.ReadKey();
        }
