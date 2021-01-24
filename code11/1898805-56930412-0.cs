    public async Task<ListResultDto<QuoteListDto>> GeQuotesTabData(int? landlordId, int? agentId,
        int? propertyTenantId)
    {
        var query = _quoteRepository.GetAll();
        if (landlordId.HasValue)
        {
            query  = query.Where(x => x.LandlordId == landlordId);
        }
        if (agentId.HasValue)
        {
            query = query.Where(x => x.AgentId == agentId);
        }
        if (propertyTenantId.HasValue)
        {
            query = query .Where(x => x.PropertyTenantId == propertyTenantId);
        }
        return new ListResultDto<QuoteListDto>(await query.ProjectTo<QuoteListDto>(ObjectMapper)
            .OrderBy(x => x.Id).ToListAsync());
    }
