     public static class EnumExt
    {
         public static void ShowAll<T>(this IEnumerable<T> list)
         {
             foreach (T item in list)
                Console.WriteLine(item);
         }
    }
     
