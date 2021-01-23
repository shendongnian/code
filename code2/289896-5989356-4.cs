    public static class EnumExt
    {
         public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
         {
             foreach (T item in list)
                action(item);
         }
    }
     
