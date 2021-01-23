    public static IEnumerable<T[]> Permutations<T>(IEnumerable<T> source) {
      if (null == source)
        throw new ArgumentNullException(nameof(source));
      T[] data = source.ToArray();
      return Enumerable
        .Range(0, 1 << (data.Length))
        .Select(index => data
           .Where((v, i) => (index & (1 << i)) != 0)
           .ToArray());
    }
