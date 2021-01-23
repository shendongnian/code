    var sets = testResult
    .Select(x => new { Key = x, Set = new HashSet<int>(x.Value.Concat(new[] { x.Key })) })
    .ToList();
    var res = sets.Where(s => sets.Any(x => x.Set.IsProperSupersetOf(s.Set)));
    var keysToRemove = res.Select(x => x.Key);
