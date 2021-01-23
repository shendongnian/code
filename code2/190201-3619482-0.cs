    var lists = new List<IEnumerable<int>>() { list1, list2, list3, list4, list5, list6 };
                
    var result = lists
        .Where(x => x.Any())
        .Aggregate(Enumerable.Intersect)
        .ToList();
