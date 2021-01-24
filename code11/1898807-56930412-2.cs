    public async Task<ListResultDto<QuoteListDto>> GeQuotesTabData(int? landlordId, int? agentId,
        int? propertyTenantId)
    {
        var list = await  _quoteRepository.GetAll()
            .WhereIf(landlordId.HasValue, x => x.LandlordId == landlordId);
            .WhereIf(agentId.HasValue, x => x.AgentId == agentId);
            .WhereIf(propertyTenantId.HasValue, x => x.PropertyTenantId == propertyTenantId)
            .ProjectTo<QuoteListDto>(ObjectMapper)
            .OrderBy(x => x.Id)
            .ToListAsync();
        return new ListResultDto<QuoteListDto>(list);
    }
