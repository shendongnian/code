    private static string Benchmark(Action methodUnderTest) {
      List<long> results = new List<long>();
      int n = 10;
      for (int i = 0; i < n; ++i) {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        methodUnderTest();
        sw.Stop();
        results.Add(sw.ElapsedMilliseconds);
      }
      var valid = results
        .OrderBy(x => x)
        .Skip(2)
        .Take(results.Count - 4)
        .ToArray();
      return $"{string.Join(", ", valid)} average : {(long) (valid.Average() + 0.5)}";
    }
