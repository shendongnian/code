    public static class Extension
    {
       public static void MethodEx<T>(this T item)
       {
          Console.WriteLine(item);
       }
    
       public static void CallForEach<T>(this List<T> list, Action<T> action)
       {
          foreach (var item in list)
             action(item);
       }
    }
