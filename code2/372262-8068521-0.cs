    public static class LinqExtensions
    {
         public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
         {
               return items == null || !items.Any();
         }
    }
