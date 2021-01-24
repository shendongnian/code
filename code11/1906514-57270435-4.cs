      // Just an OrderBy...
      var result1 = dict1
        .OrderByDescending(pair => pair.Value);
      // It may appear, that dict1 doesn't have corresponding value
      // that's why we have to introduce "found" variable
      var result2 = dict2
        .Select(pair => {
          bool found = dict1.TryGetValue(pair.Key, out var value);
          return new {
            pair,
            found,
            value
          };
        })
        .OrderByDescending(item => item.found)
        .ThenByDescending(item => item.value)
        .Select(item => item.pair);
     Console.WriteLine(string.Join(Environment.NewLine, result1); 
     Console.WriteLine();
     Console.WriteLine(string.Join(Environment.NewLine, result2); 
