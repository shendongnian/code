        var results = query.Select(x => new TableListEntry
        {
            Id = x.Id,
            Name = x.Name,
            Date = x.Date,
            Type = x.Type,
            // ... etc.
        }).ToList();
