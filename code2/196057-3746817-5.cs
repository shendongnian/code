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
