    public static bool ScrambledEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
    {
      var deletedItems = list1.Except(list2).Any();
      var newItems = list2.Except(list1).Any();
      return !newItems && !deletedItems;          
    }
