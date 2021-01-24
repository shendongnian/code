    int maxCount = list.GroupBy(entry => entry.Field1)
        .OrderByDescending(grouping => grouping.Count())
        .First()
        .Count();
    
    List<string> result = list.GroupBy(entry => entry.Field1)
        .Where(item => item.Count() == maxCount)
        .Select(x => x.Key)
        .ToList();
