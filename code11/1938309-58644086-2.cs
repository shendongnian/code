     public static class NullExtensions
     {
         public static void UpdateIfNotNull<T>(this T item, Action<T> update)
             where T : class
         {
             if (item != null)
             {
                 update(item);
             }
         }
     }
