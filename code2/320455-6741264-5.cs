    void DoTimings(int n)
    {
        Stopwatch sw = new Stopwatch();
        int time = 0;
        double dummy = 0;
        List<double> items = new List<double>(); // Reuse same list
        // populate items with random numbers, excluded for brevity
        sw.Start();
        for (int i = 0; i < n; i++)
        {
            dummy += Mean(items);
            time += sw.ElapsedMilliseconds;
        }
        sw.Stop();
        
        Console.WriteLine(dummy);
        Console.WriteLine(time / n);
    }
