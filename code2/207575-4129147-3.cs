    static void Test2<T>(string testName, Func<T> test, int iterations = 1000000)
    {
      //long [] results = new long [iterations];
      long min = long.MaxValue;
      long max = long.MinValue;
      // print header 
      for (int i = 0; i < 100; i++) // warm up the cache 
      {
        test();
      }
      var timer = System.Diagnostics.Stopwatch.StartNew(); // time whole process 
      long start;
      long delta;
      long sum = 0;
      for (int i = 0; i < iterations; i++)
      {
        start = Stopwatch.GetTimestamp();
        test();
        delta = Stopwatch.GetTimestamp() - start;
        if (delta < min) min = delta;
        if (delta > max) max = delta;
        sum += delta;
      }
      timer.Stop();
      double ticksPerMillisecond = Stopwatch.Frequency / 1000.0;
      Console.WriteLine("Time(ms): {0,3}/{1,10}/{2,8} ({3,10})", min / ticksPerMillisecond, sum / ticksPerMillisecond / iterations, max / ticksPerMillisecond, sum);
      Console.WriteLine("Ticks:    {0,3}/{1,10}/{2,8} ({3,10})", min, sum / iterations, max, sum);
      Console.WriteLine();
    }
