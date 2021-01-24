    public static IEnumerable<T> RemoveDoubles<T>(
      this IEnumerable<T> items) 
    {
      T previous = default(T);
      bool first = true;
      foreach(T item in items)
      {
        if (first || !item.Equals(previous)) yield return item;
        previous = item;
        first = false;
      }
    }
