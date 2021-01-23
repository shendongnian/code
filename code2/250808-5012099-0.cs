    var intersect = list1.Intersect(list2).ToList();
    var groups1 = list1.Where(e => intersect.Contains(e)).GroupBy(e => e);
    var groups2 = list2.Where(e => intersect.Contains(e)).GroupBy(e => e);
    
    var allGroups = groups1.Concat(groups2);
    
    return allGroups.GroupBy(e => e.Key)
        .SelectMany(group => group
            .Where(g => g.Count() == group.Min(g1 => g1.Count())))
        .SelectMany(e => e).ToList();
