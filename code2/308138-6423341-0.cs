     internal static class Helper
     {
           internal static IEnumerable<T> Enumerable(this T obj)
           {
                yield return obj;
           }
     }
     //
     var enumerable = 42.Enumerable();
