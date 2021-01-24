    public async Task<IList<Class4>> GetClass4BetweenDates(string id, DateTime fromDate, DateTime toDate)
    {
        var filterDefinition = Builders<Class1>.Filter.Where(x => x.Id == id &&
                                                                  x.Class2List.Any(a => a.Class3List.Any(b => b.Class4List.Any(c => c.CreateDate >= fromDate && 
                                                                                                                                    c.CreateDate <= toDate))));
        var class1 = await _context.GetCollection<Class1>().Find(filterDefinition).ToListAsync();  
        var class4List = new List<Class4>();
        if (class1 == null)
            return class4List; 
        foreach (var class2 in class1.Class2List)
        {
            foreach (var class3 in class2.Class3List)
            {
                if (class3.Class4List.Any())
                    class4List.AddRange(class3.Class4List);
            }
        }
        return class4List;       
    }
