    members = await _context.Members
        .Where(s => EF.Functions.Like(s.FirstNames, searchTerm))
        .Select(s => new Members
        {
            Id = s.Id,
            CardIds = s.Select(a =>
                new AdditionalCard
                {
                    CardId = a.CardId
                }
            )
            .Union(s.MemberAdditionalCards
                .Select(a => new AdditionalCard
                {
                    CardId = a.CardId
                }))
            .ToList()
        })
        .AsNoTracking()
        .ToListAsync();
