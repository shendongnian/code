    Dictionary<string, int[]> dictionary = source
        .GroupBy(kvp => kvp.Key)
        .Select(grp => new { Key = grp.Key, Items = grp.Select(kvp => kvp.Value).ToArray())
        .OrderByDescending(i => i.Items.Length)
        .ToDictionary(i => i.Key, i => i.Items);
