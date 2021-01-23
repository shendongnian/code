    var first = str.GroupBy(s => s)
                   .ToDictionary(g => g.Key, g => g.Count());
    var second = lst.GroupBy(s => s)
                    .ToDictionary(g => g.Key, g => g.Count());
    bool equals = first.OrderBy(kvp => kvp.Key)
                       .SequenceEquals(second.OrderBy(kvp => kvp.Key));
