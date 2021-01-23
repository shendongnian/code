    public static IEnumerable<T[]> Filter<T>(T[,] source, Func<T[], bool> predicate)
    {
      for (int i = 0; i < source.GetLength(0); ++i)
      {
        T[] values = new T[source.GetLength(1)];
        for (int j = 0; j < values.Length; ++j)
        {
          values[j] = source[i, j];
        }
        if (predicate(values))
        {
          yield return values;
        }
      }      
    }
