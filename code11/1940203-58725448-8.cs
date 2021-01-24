      public static partial class EnumerableExtensions {
        public static IEnumerable<T[]> ToBatch<T>(this IEnumerable<T> source,
                                                  Func<ICollection<T>, T, bool> addToBatch) {
    
          if (null == source)
            throw new ArgumentNullException(nameof(source));
          else if (null == addToBatch)
            throw new ArgumentNullException(nameof(addToBatch));
    
          List<T> batch = new List<T>();
    
          foreach (T item in source) {
            // Shall we start a new batch?
            if (batch.Count > 0 && !addToBatch(batch, item)) {
              yield return batch.ToArray();
    
              batch.Clear();
            }
    
            batch.Add(item);
          }
    
          if (batch.Count > 0) // do we have a last batch?
            yield return batch.ToArray();
        }
      }
