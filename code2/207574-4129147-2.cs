    static void Test2<T>(string testName, Func<T> test, int iterations = 1000000)
    {
      long [] results = new long [iterations];
      // print header 
      for (int i = 0; i < 100; i++) // warm up the cache 
      {
        test();
      }
      var timer = System.Diagnostics.Stopwatch.StartNew(); // time whole process 
      long start;
      for (int i = 0; i < results.Length; i++)
      {
        start = Stopwatch.GetTimestamp();
        test();
        results[i] = Stopwatch.GetTimestamp() - start;
      }
      timer.Stop();
      double ticksPerMillisecond = Stopwatch.Frequency / 1000.0;
      Console.WriteLine("Time(ms): {0,3}/{1,10}/{2,8} ({3,10})", results.Min(t => t / ticksPerMillisecond), results.Average(t => t / ticksPerMillisecond), results.Max(t => t / ticksPerMillisecond), results.Sum(t => t / ticksPerMillisecond));
      Console.WriteLine("Ticks:    {0,3}/{1,10}/{2,8} ({3,10})", results.Min(), results.Average(), results.Max(), results.Sum());
      Console.WriteLine();
    }
