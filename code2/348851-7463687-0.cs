    IEnumerable<string> MultiConcat(params IEnumerable<string>[] lists)
    {
        if (lists == null) {
            return null;
        }
        if (lists.Length == 0) {
            return Enumerable.Empty<string>();
        }
        return lists.Aggregate(new[] { string.Empty } as IEnumerable<string>,
                       (acc, list) => acc.SelectMany(s1 => list.Select(s2 => s1 + s2)));
    }
