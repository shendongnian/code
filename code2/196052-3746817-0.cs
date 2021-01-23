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
                                .ToArray(),
                            IsComplete = unique.Count == queryArray.Length
                        };
                })
            .Where(x => x.IsComplete)
            .Select(x => new[] 
                { 
                    x.Followers.First().Index, 
                    x.Followers.Last().Index 
                })
            .OrderBy(x => x[1] - x[0]);
        var best = segments.FirstOrDefault();
        return best;
    }
