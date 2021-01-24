    public async Task<IList<Class1>> GetClass4BetweenDates(string id, DateTime fromDate, DateTime toDate)
    {
        var filterDefinition = Builders<Class1>.Filter.Where(x => x.Id == id &&
                                                                  x.Class2List.Any(a => a.Class3List.Any(b => b.Class4List.Any(c => c.CreateDate >= fromDate && 
                                                                                                                                    c.CreateDate <= toDate))));
        return await _context.GetCollection<Class1>().Find(filterDefinition).ToListAsync();            
    }
