    public static class LinqExtensions
    {
      public static IEnumerable<T[]> Where<T>(this T[,] source, Func<T[], bool> predicate)
      {
        if (source == null) throw new ArgumentNullException("source");
        if (predicate == null) throw new ArgumentNullException("predicate");
        return WhereImpl(source, predicate);
      }
  
      private static IEnumerable<T[]> WhereImpl<T>(this T[,] source, Func<T[], bool> predicate)
      {      
        for (int i = 0; i < source.GetLength(0); ++i)
        {
          T[] values = new T[source.GetLength(1)];
          for (int j = 0; j < values.Length; ++j)
          {
            values[j] = source[i, j];
          }
          if (predicate(values))
          {
            yield return values;
          } 
        }
      }    
    }
