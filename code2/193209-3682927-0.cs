    public static T LastOrDefault<T>(this IEnumerable<T> list)
    {
      T val = null;
      foreach(T item in list)
      {
         val = item;
      }
      return val;
    }
