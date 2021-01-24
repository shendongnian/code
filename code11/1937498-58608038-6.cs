        private static IEnumerable<T> IntersectAll<T>(IEnumerable<IEnumerable<T>> source, 
                                                  IEqualityComparer<T> comparer = null) {
          if (null == source)
            throw new ArgumentNullException(nameof(source));
    
          if (null == comparer)
            comparer = EqualityComparer<T>.Default;
    
          if (null == comparer)
            throw new ArgumentNullException(nameof(comparer), 
              $"No default comparer for {typeof(T).Name}");
    
          Dictionary<T, int> prior = null;
    
          foreach (var line in source) {
            Dictionary<T, int> current = line
              .GroupBy(item => item, comparer)
              .ToDictionary(chunk => chunk.Key, chunk => chunk.Count(), comparer);
    
            if (null != prior)
              prior = current
                .Where(item => prior.ContainsKey(item.Key))
                .ToDictionary(item => item.Key, item => Math.Min(item.Value, prior[item.Key]));
            else
              prior = current;
          }
    
          return (prior ?? new Dictionary<T, int>())
            .SelectMany(item => Enumerable.Repeat(item.Key, item.Value));
        }
