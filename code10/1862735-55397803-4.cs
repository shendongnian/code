    private static IEnumerable<T[]> Cartesian<T>(IEnumerable<IEnumerable<T>> source) {
      T[][] lists = source
        .Select(line => line.ToArray())
        .ToArray();
      if (source.Any(line => !line.Any()))
        yield break;
      int[] indexes = new int[lists.Length];
      do {
        yield return lists.Select((line, index) => line[indexes[index]]).ToArray();
        for (int i = 0; i < indexes.Length; ++i)
          if (++indexes[i] < lists[i].Length) 
            break;
          else
            indexes[i] = 0;
      }
      while (!indexes.All(index => index == 0));
    }
