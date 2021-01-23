     internal static IEnumerable<T> Concat<T>(params T[] objs)
     {
          return objs;
     }
     internal static IEnumerable<T> Concat<T>(this IEnumerable<T> e, params T[] objs)
     {
          return e.Concat(objs);
     }
     internal static IEnumerable<T> Concat<T>(this IEnumerable<T> e, params IEnumerable<T>[] seqs)
     {
          foreach (T t in e) yield return t;
          foreach (var seq in seqs)
               foreach (T t in seq) yield return t;
     }
     // this allows you to
     var e1 = Concat(1,2,3);       // 1,2,3
     var e2 = e1.Concat(4,5,6);    // 1,2,3,4,5,6,
     var e3 = e2.Concat(e2, e1, Concat(42)); // 1,2,3,4,5,6,1,2,3,4,5,6,1,2,3,42
