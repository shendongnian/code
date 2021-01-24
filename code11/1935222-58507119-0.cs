    GroupedItem[] = groupedItems
        .GroupBy(g => g.GroupName)
        .Select(g => new GroupedItem { GroupName = g.Key, Min = g.Min(x => x.Price), Max = g.Max(x => x.Price), Items = g.ToArray() })
        .SelectMany(g => g.Items)
        .ToArray();
