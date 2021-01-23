    static void DoIt()
    {
        int NumberOfTests = 1000;
    
        Random rnd = new Random();
    
        TimeSpan totalTime = TimeSpan.Zero;
        for (int i = 0; i < NumberOfTests; ++i)
        {
            // fill the dictionary
            int DictionarySize = rnd.Next(1000, 10000);
            var dict = new Dictionary<int, string>();
            while (dict.Count < DictionarySize)
            {
                int key = rnd.Next(1000000, 9999999);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, "x");
                }
            }
            // Okay, sort
            var sw = Stopwatch.StartNew();
            var sorted = (from kvp in dict
                            orderby kvp.Key
                            select kvp).ToList();
            sw.Stop();
            totalTime += sw.Elapsed;
            Console.WriteLine("{0:N0} items in {1:N6} ms", dict.Count, sw.Elapsed.TotalMilliseconds);
        }
        Console.WriteLine("Total time = {0:N6} ms", totalTime.TotalMilliseconds);
        Console.WriteLine("Average time = {0:N6} ms", totalTime.TotalMilliseconds / NumberOfTests);
