     public static class Extensions {
           public static bool HasElements(this IEnumerable<T> l1, IEnumerable<T> l2, IEqualityComparer<T> comparaer){
              return l1.Intersect(l2, comparer).Count() == l2.Count();
 
              } 
     }
