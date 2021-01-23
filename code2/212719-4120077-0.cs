    public static class IEnumerableExtensions {
      public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list, Random rnd) {
        List<T> items = new List<T>(list);
        for (int i = 0; i < items.Count; i++) {
          int pos = rnd.Next(i, items.Count);
          yield return items[pos];
          items[pos] = items[i];
        }
      }
    }
