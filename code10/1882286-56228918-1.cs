List<Records> r = records
    .GroupBy(a => a.ID)
    .Select(b => new Record
            {
                ID = b.Key,
                Name = b.First().Name,
                Rev = b.OrderBy(o => o.status == "Cancel")
                       .ThenByDescending(o => o.Rev)
                       .First().Rev
        }).ToList();
