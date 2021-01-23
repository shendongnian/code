    public static class MyEnumerable {
      public static IEnumerable<int> AlternateRange(int start, int count) {
        for (int i = start; i < start + count; i += 2) {
          yield return i;
        }
      }
    }
