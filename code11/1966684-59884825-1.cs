    public async Task<List<string>> GetFruitDetailedType()
    {
        return await GetFruitsQueryable().SelectMany(x => x.DetailedType)
                                         .Distinct()
                                         .ToListAsync();
    }
