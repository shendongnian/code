    public static bool HasAtleast<T>(this IEnumerable<T> source, int minCount)
    {
       if(source == null)
          throw new ArgumentNullException("source");
     
       if(minCount <= 0)
          return true; 
       return source.Take(minCount).Count() == minCount;
    }
