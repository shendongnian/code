      var result = dict
        .Select(pair => new {
          key = pair.Key,
          value = pair.Value.Intersect(values).ToList()
        })
        .Where(item => item.value.Any())
        .ToDictionary(item => item.key, item => item.value);
      Console.Write(string.Join(Environment.NewLine, result
        .Select(pair => $"{pair.Key} : [{string.Join(", ", pair.Value)}]"))); 
