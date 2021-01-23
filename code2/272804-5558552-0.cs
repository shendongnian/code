    public static class Utils {
      public static IEnumerable<int> Range(int start, int count) {
        for (var i = start; i <= count; i++) {
          yield return i;
        }
      }
    }
