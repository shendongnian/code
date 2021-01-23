    var stuff = regex.Matches(input)
        .Cast<Match>() // We're confident everything will be a Match!
        .Select(c => c.Value.ToLowerInvariant())
        .Where(c => !keywords.Contains(c))
        .GroupBy(c => c)
        .Select(g => new { Word = g.Key, Count = g.Count() })
        .OrderByDescending(g => g.Count)
        .ThenBy(g => g.Word);
