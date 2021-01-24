return queryJoin.ToList()
That executes the query and returns the results as a list. You need nothing more than :
    public IEnumerable<StageTwo> Stage2Entries()
    {
        var queryJoin = (from inn in db.Input.Take(1)
                             join y in db.InputY on inn.YAction equals y.YAction
                             orderby inn.Id descending
                             select new StageTwo
                             {
                                 Id = inn.Id,
                                 Party = inn.XParty,
                                 Currency = inn.Curr,
                                 DrCr = y.DrAccount1,
                                 Account = y.YAction,
                                 Amount = inn.Amount
                             });
        return queryJoin.ToList();
    }
`IEnumerable<T>` is the interface implemented by all *collections*. `StageTwo` represents a a single object though so it doesn't make any sense for it to implement `IEnumerable<T>`
If you use EF/EF Core, you can execute the query asynchronously (ie without blocking) with `ToListAsync()` :
    public async Task<IEnumerable<StageTwo>> Stage2Entries()
    {
        var list=await queryJoin.ToListAsync();
        return list;
    }
