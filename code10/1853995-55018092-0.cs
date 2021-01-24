    var entries = _keys
        .OrderByDescending(entry => RadarContext.FromTrim(entry.Key, _logger))
        .Take(100)
        .ToArray();
    foreach (var entry in entries)
    {
        if (entry.Value < tminus1)
        {
            await actionblock.SendAsync(entry.Key);
        }
    }
