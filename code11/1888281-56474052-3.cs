    private static string Benchmark(Action<int[]> methodUnderTest) {
      List<long> results = new List<long>();
      int n = 10;
      for (int i = 0; i < n; ++i) {
        Random random = new Random(1);
        int[] arr = Enumerable
          .Range(0, 10000000)
          .Select(x => random.Next(1000000000))
          .ToArray();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        methodUnderTest(arr);
        sw.Stop();
        results.Add(sw.ElapsedMilliseconds);
      }
      var valid = results
        .OrderBy(x => x)
        .Skip(2)                  // get rid of top 2 runs
        .Take(results.Count - 4)  // get rid of bottom 2 runs
        .ToArray();
      return $"{string.Join(", ", valid)} average : {(long) (valid.Average() + 0.5)}";
    }
