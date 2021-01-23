    public static IEnumerable<U> CastCollection<T, U>(this IList<T> items) where U : class
    {
       var collection = new List<U>();
       foreach (var item in items)
       {
          if (item is U)
          {
               var newItem = item as U;
               collection.Add(newItem);
          }
      }
      return collection;
    }
