    members = await _context.Members
    	.Where(s => EF.Functions.Like(s.FirstNames, searchTerm))
    	.Select(s => new Members
    	{
    		Id = s.Id,
    		CardIds = new List<AdditionalCard>
    		{
    			new AdditionalCard
    			{
    				CardId = s.CardId
    			}
    		}
    		.Union(s.MemberAdditionalCards
    			.Select(a => new AdditionalCard
    			{
    				CardId = a.CardId
    			}))
    	})
    	.AsNoTracking()
    	.ToListAsync();
