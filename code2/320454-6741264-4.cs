    void DoTimings(int n)
    {
        Stopwatch sw = new Stopwatch();
        int time = 0;
        double dummy = 0;
        for (int i = 0; i < n; i++)
        {
            List<double> items = new List<double>();
            // populate items with random numbers, excluded for brevity
            
            sw.Start();
            dummy += Mean(items);
            sw.Stop();
            time += sw.ElapsedMilliseconds;
        }
        
        Console.WriteLine(dummy);
        Console.WriteLine(time / n);
    }
