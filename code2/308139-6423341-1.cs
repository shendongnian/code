     internal static IEnumerable<T> Concat<T>(params T[] objs)
     {
          return objs;
     }
     internal static IEnumerable<T> Concat<T>(this IEnumerable<T> enum, params T[] objs)
     {
          return enum.Concat(objs);
     }
     internal static IEnumerable<T> Concat<T>(this IEnumerable<T> enum, params IEnumerable<T>[] seqs)
     {
          foreach (T t in enum) yield return t;
          foreach (var seq in seqs)
               foreach (T t in seq) yield return t;
     }
     // this allows you to
     var e1 = Concat(1,2,3);       // 1,2,3
     var e2 = e1.Concat(4,5,6);    // 1,2,3,4,5,6,
     var e3 = e1.Concat(e2, e2, e1, Concat(42)); // 1,2,3,4,5,6,1,2,3,4,5,6,1,2,3,42
