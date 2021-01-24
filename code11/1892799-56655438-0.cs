    Dictionary<string, Dictionary<string, int>> results = intents
        .ToDictionary(
            item => item.Item1,
            item => item.Item2.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count()));
