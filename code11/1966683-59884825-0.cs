    public async Task<List<string>> GetFruitDetailedType() 
    {
        var qry = await GetFruitsQueryable().Select(v => v.DetailedType).ToListAsync();
        return qry.SelectMany(x => x).Distinct().ToList();
    }
