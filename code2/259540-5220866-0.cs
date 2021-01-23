    /// <summary>
    /// Returns an inifinte sequence of integers starting with 1
    /// </summary>
    public static IEnumerable<int> InfiniteSequence() {
      int value = 0;
      while (true) {
        yield return ++value;
      }
    }
