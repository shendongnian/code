    public static class CollectionHelpers {
      public static void RemoveWhere<T>(this IList<T> list, Func<T, bool> selector) {
        var elementsToRemove = list.Where(expression).ToList();
        foreach (var element in list) {
          list.Remove(element);
        }
      }
    }
