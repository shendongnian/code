List<Records> r = records
    .GroupBy(a => a.ID)
    .Select(b => new Record
            {
                ID = b.Key,
                Name = b.First().Name,
                Rev = b.OrderByDescending(o => o.status == "Cancel")
                       .ThenBy(o => o.Rev)
                       .First().Rev
        }).ToList();
