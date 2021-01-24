    private static void UnderTestOrderBySelect() {
      Random random = new Random(1);
      int[] arr = Enumerable
        .Range(0, 10000000)
        .Select(x => random.Next(1000000000))
        .ToArray();
      var query = arr.OrderBy(x => x).Select(x => x + 5); 
      foreach (var item in query)
        ;
    }
    private static void UnderSelectOrderBy() {
      Random random = new Random(1);
      int[] arr = Enumerable
        .Range(0, 10000000)
        .Select(x => random.Next(1000000000))
        .ToArray();
      var query = arr.Select(x => x + 5).OrderBy(x => x);  
      foreach (var item in query)
        ;
    }
