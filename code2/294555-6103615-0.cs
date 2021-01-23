    public static IEnumerable<int> ExampleWhere(IEnumerable<int> values) {
      foreach (var x in values) {
        if (x == 1) {
          yield return 1;
        }
      }
    }
