    public static int[] SmallestWindow(int[] inputArray, int[] queryArray)
    {
        var indexed = queryArray
            .SelectMany(x => inputArray
                                 .Select((y, i) => new
                                     {
                                         Value = y,
                                         Index = i
                                     })
                                 .Where(y => y.Value == x))
            .OrderBy(x => x.Index)
            .ToList();
        var segments = indexed
            .Select(x =>
                {
                    var unique = new HashSet<int>();
                    return new
                        {
                            Item = x,
                            Followers = indexed
                                .Where(y => y.Index >= x.Index)
                                .TakeWhile(y => unique.Count != queryArray.Length)
                                .Select(y =>
                                    {
                                        unique.Add(y.Value);
                                        return y;
                                    })
                                .ToList(),
                            IsComplete = unique.Count == queryArray.Length
                        };
                })
            .Where(x => x.IsComplete);
        var queryIndexed = segments
            .Select(x => x.Followers.Select(y => new
                {
                    QIndex = Array.IndexOf(queryArray, y.Value),
                    y.Index,
                    y.Value
                }).ToArray());
        var queryOrdered = queryIndexed
            .Where(item =>
                {
                    var qindex = item.Select(x => x.QIndex).ToList();
                    bool changed;
                    do
                    {
                        changed = false;
                        for (int i = 1; i < qindex.Count; i++)
                        {
                            if (qindex[i] <= qindex[i - 1])
                            {
                                qindex.RemoveAt(i);
                                changed = true;
                            }
                        }
                    } while (changed);
                    return qindex.Count == queryArray.Length;
                });
        var result = queryOrdered
            .Select(x => new[]
                {
                    x.First().Index,
                    x.Last().Index
                })
            .OrderBy(x => x[1] - x[0]);
        var best = result.FirstOrDefault();
        return best;
    }
