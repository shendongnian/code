    public static class MultiEnumerableExtensions {
      public static IEnumerable<T> Pack<T>(this T item) {
        return new T[] { item };
      }
      public static IEnumerable<T> Flatten<T>(
        this IEnumerable<IEnumerable<T>> multiList) {
        return multiList.SelectMany(x => x);
      }
    }
