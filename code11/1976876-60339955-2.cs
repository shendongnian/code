      using System.Linq;
      ...
      float[] array = Enumerable
        .Range(1, N)
        .Select(i => ReadSingle($"Please, provide item #{i}"))
        .ToArray();
