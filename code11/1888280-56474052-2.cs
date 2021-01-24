    private static void UnderTestOrderBySelect(int[] arr) {
      var query = arr.OrderBy(x => x).Select(x => x + 5); 
      foreach (var item in query)
        ;
    }
    private static void UnderTestSelectOrderBy(int[] arr) {
      var query = arr.Select(x => x + 5).OrderBy(x => x);  
      foreach (var item in query)
        ;
    }
