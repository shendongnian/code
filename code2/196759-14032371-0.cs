    public static bool Same<T>(this IEnumerable<T> xs) {
      return !xs.Any() || !xs.Skip(!xs.Skip(1).All(x => x.Equals(xs.First()));
    }
 
    public static IEnumerable<T> CommonPrefix<T>(this IEnumerable<IEnumerable<T>> xss) {
      var r = new List<T>();
      var es = xss.Select(x => x.GetEnumerator()).ToList();
      while (es.Select(x => x.MoveNext()).All(x => x))
         if (!es.Select(x => x.Current).Same())
            return r;
         return r;
      }
    }
