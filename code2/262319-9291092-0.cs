    var loadingIndexes = InputList.Select((r, i) => new { Row=row, Index=i })
                                  .Where(x => x.Row.Any(e =>
                                      e.ToString().Contains("Loading"))
                                  .Select(x => x.Index);
    var betweenLines = loadingIndexes
                           .Select(i => InputList
                               .Skip(i)
                               .TakeWhile(r => !r.Any(e =>
                                                      e.ToString().Contains("FULL")))
                               .ToList())
                           .ToList();
