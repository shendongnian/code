    private static string UnderTest(int size) {
      int pos = 0, neg = 0, zeros = 0;
      int p = 0, n = 0, z = 0;
      Random random = new Random(0);
      int[] arr = Enumerable
        .Range(0, size)
        .Select(x => random.Next(-1, 2))
        .ToArray();
      Stopwatch sw = new Stopwatch();
      sw.Start();
      // Three Linq loops (expected to be 3 three times slower)
      pos = arr.Sum(e => e > 0 ? 1 : 0);    
      neg = arr.Sum(e => e < 0 ? 1 : 0);
      zeros = arr.Sum(e => e == 0 ? 1 : 0);
      sw.Stop();
      Stopwatch sw2 = new Stopwatch();
      sw2.Start();
      // Just 1 loop 
      foreach (var item in arr) {
        if (item > 0) p++;
        else if (item < 0) n++;
        else z++;
      }
      sw2.Stop();
      return $"{sw.Elapsed} vs. {sw2.Elapsed} ratio: {((double)sw.Elapsed.Ticks) / sw2.Elapsed.Ticks:f3}";
    } 
