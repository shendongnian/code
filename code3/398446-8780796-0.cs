     public static class EnumerableEx
     {
         public static IEnumerable<T> EmptyIfNull(this IEnumerable<T> source)
         {
             return source ?? Enumerable.Empty<T>();
         }
     }
