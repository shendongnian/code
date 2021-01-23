    public static class EnumerableExtensions {
      public static void ForEach<T>(this IEnumerable<T> self, Action<T> action) {
        if (self != null) {
          foreach (var element in self) {
            action(element);
          }
        }
      }
    }
