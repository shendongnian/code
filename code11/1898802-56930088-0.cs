    public async Task<ListResultDto<QuoteListDto>> GeQuotesTabData(int? landlordId, int? agentId,
        int? propertyTenantId)
    {
        <SomeType> query;
        if (landlordId.HasValue)
        {
            query = _quoteRepository.GetAll().Where(x => x.LandlordId == landlordId);
        }
        if (agentId.HasValue)
        {
            query = _quoteRepository.GetAll().Where(x => x.AgentId == agentId);
        }
        if (propertyTenantId.HasValue)
        {
            query = _quoteRepository.GetAll().Where(x => x.PropertyTenantId == propertyTenantId);
        }
        return new ListResultDto<QuoteListDto>(await query.ProjectTo<QuoteListDto>(ObjectMapper)
            .OrderBy(x => x.Id).ToListAsync());
    }
