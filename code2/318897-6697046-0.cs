    public static class MyExtensions {
      public static void ForEach(this IEnumerable<T> enumerable, Action<T> action) {
        foreach (var entry in enumerable)
          action(entry);
      }
    }
