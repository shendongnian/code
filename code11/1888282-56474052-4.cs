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
    // See Marc Gravell's comment; let's compare Linq and inplace Array.Sort
    private static void UnderTestInPlaceSort(int[] arr) {
      var tmp = arr;
      var x = new int[tmp.Length];
      for (int i = 0; i < tmp.Length; i++)
        x[i] = tmp[i] + 5;
      Array.Sort(x);
    }
