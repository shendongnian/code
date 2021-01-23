    public static class Utils {
      private class RangeIterator : IEnumerable<int>, IEnumerator<int> {
        ... 
        // iterator state machine
      }
      public static IEnumerable<int> Range(int start, int count) {
        return new RangeIterator(start, count);
      }
    }
