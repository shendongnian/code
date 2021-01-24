    var a = new string[] {"1", "2", "2", "3", "4", "4"};
    var b = new string[] {"2", "3"};
    ...
    
    var subtract = b
      .GroupBy(item => item)
      .ToDictionary(chunk => chunk.Key, chunk => chunk.Count());
    
    var result = a
      .GroupBy(item => item)
      .Select(chunk => new {
         value = chunk.Key,
         count = chunk.Count() - (subtract.TryGetValue(chunk.Key, out var v) ? v : 0)  
       })
      .Where(item => item.count > 0)
      .SelectMany(item => Enumerable.Repeat(item.value, item.count));
    // Let's have a look at the result
    Console.Write(string.Join(", ", result));
