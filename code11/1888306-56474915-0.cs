    private static T[][][] Flatten<T>(T[,,] value) {
      if (null == value)
        return null;
      return Enumerable
        .Range(0, value.GetLength(0))
        .Select(r => Enumerable
           .Range(0, value.GetLength(1))
           .Select(c => Enumerable
              .Range(0, value.GetLength(2))
              .Select(h => value[r, c, h])
              .ToArray())
           .ToArray())
        .ToArray();
    }
