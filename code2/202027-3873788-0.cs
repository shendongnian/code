    return results
        .GroupBy(r => r.PrimaryKey)
        .Select(grp => new ObjectA
        {
            PrimaryKey = grp.Key,
            Status = grp.First().Status,
            Items = grp.Where(i => i.ItemName != null).Select(i => new Item { Name = i.ItemName }).ToList()
        }).ToList();
