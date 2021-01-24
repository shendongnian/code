       public static partial class EnumerableExtensions {
         public static IEnumerable<T> Interleave<T>(this IEnumerable<T> source, 
                                                    params IEnumerable<T>[] others) {
          if (null == source)
            throw new ArgumentNullException(nameof(source));
          else if (null == others)
            throw new ArgumentNullException(nameof(others));
    
          IEnumerator<T>[] enums = new IEnumerator<T>[] { source.GetEnumerator() }
              .Concat(others
              .Where(item => item != null)
              .Select(item => item.GetEnumerator()))
            .ToArray();
    
          try {
            bool hasValue = true;
    
            while (hasValue) {
              hasValue = false;
    
              for (int i = 0; i < enums.Length; ++i) {
                if (enums[i] != null && enums[i].MoveNext()) {
                  hasValue = true;
    
                  yield return enums[i].Current;
                }
                else {
                  enums[i].Dispose();
                  enums[i] = null;
                }
              }
            }
          }
          finally {
            for (int i = enums.Length - 1; i >= 0; --i)
              if (enums[i] != null)
                enums[i].Dispose();
          }
        }
      }
