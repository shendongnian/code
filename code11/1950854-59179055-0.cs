      string[] keys = { "A", "B", "C", "D", "E", "F" };
      string[] values = { "green", "blue", "yellow" };
      Dictionary<string, string> result = Enumerable
        .Range(0, keys.Length)
        .ToDictionary(i => keys[i], i => values[i % values.Length]);
