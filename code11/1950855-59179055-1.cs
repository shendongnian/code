      string[] keys = { "A", "B", "A", "D", "C","E" };
     string[] keys = { "A", "B", "A", "D", "C", "E" };
      string[] values = { "green", "blue", "yellow" };
      Dictionary<string, string> result = keys
        .Distinct()
        .Select((key, i) => new {
          key,
          value = values[i % values.Length]
        })
        .ToDictionary(item => item.key, item => item.value);
