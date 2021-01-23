    foreach (var entry in SmartEnumerable.Create(cmp))
    {
        var cm = entry.Value;
        if (entry.IsLast)
        {
            ...
        }
    }
