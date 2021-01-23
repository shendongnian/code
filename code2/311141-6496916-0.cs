    var list = new List<int>() { 1, 3, 4, 5, 5, 6, 7, 7 };
    var duplicates =  list.GroupBy(x => x)
                          .Where(g => g.Count() > 1)
                          .Select(g => g.Key)
                          .ToList();
