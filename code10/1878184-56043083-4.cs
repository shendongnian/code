    private static List<int> MySort(IEnumerable<int> list) {
      var groups = list
       .GroupBy(item => item)
       .Select(chunk => new {
         value = chunk.Key,
         count = chunk.Count()
       })
       .OrderBy(item => item.value)
       .ToArray();
      int maxCount = groups.Max(group => group.count);
      return Enumerable
        .Range(0, maxCount)
        .SelectMany(i => groups
           .Where(chunk => chunk.count > i)
           .Select(chunk => chunk.value))
        .ToList();
    }
