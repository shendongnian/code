    public static class CollectionHelpers {
      public static void RemoveWhere<T>(this IList<T> list, Expression<Func<T, bool>> expression) {
        var elementsToRemove = list.Where(expression).ToList();
        foreach (var element in list) {
          list.Remove(element);
        }
      }
    }
