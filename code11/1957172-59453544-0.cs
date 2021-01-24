    public static IEnumerable<IEnumerable<T>> Combinations<T>(
      this IEnumerable<T> elements, int k) {
      if (null == elements)
        throw new ArgumentNullException(nameof(elements));
      else if (k < 0)
        throw new ArgumentOutOfRangeException(nameof(k));
      T[] alphabet = elements.ToArray();
      if (alphabet.Length <= 0)
        yield break;
      else if (k == 0)
        yield break;
      int[] indexes = new int[k];
      do {
        yield return indexes
          .Select(i => alphabet[i])
          .ToArray();
        for (int i = indexes.Length - 1; i >= 0; --i)
          if (indexes[i] >= alphabet.Length - 1)
            indexes[i] = 0;
          else {
            indexes[i] += 1;
            break;
          }
      }
      while (!indexes.All(index => index == 0));
    }
