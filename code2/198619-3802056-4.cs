    public static bool HasAtleast<T>(this IEnumerable<T> source, int minCount)
    {
       if(source == null)
          throw new ArgumentNullException("source");
     
       if(minCount <= 0)
          return true; 
       return source.Take(minCount).Count() == minCount;
    }
    public static bool HasExactly<T>(this IEnumerable<T> source, int count)
    {
       if(source == null)
          throw new ArgumentNullException("source");
     
       return source.Take(count + 1).Count() == count;
    }
