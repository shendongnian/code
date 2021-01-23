    public static void AddRangeWhere<T>(this IEnumerable<T> list, IEnumerable<T> sourceList, Func<T, bool> predicate)
      {
       if (list != null)
       {
        List<T> newRange = new List<T>();
    
        foreach (var item in sourceList)
        {
         if (predicate(item))
          newRange.Add(item);
        }
    
        list.Concat(newRange);
       }
      }
