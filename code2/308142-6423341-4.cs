     internal static IEnumerable<T> Enumerable<T>(this T obj)
     {
          yield return obj;
     }
     //
     var enumerable = 42.Enumerable();
