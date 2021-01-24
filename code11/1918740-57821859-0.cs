    public async Task Search(Expression<Func<T, bool>> criteria, Func<T, object>[] order)
    {
        var elems = await Service.SearchAsync(criteria, false);
        var sorted = elems.AsEnumerable().OrderBy(order.First());
        foreach(var subOrder in order.Skip(1)){
          sorted = sorted.ThenBy(subOrder);
        }
        Searchlist.AddRange(sorted)
    }
    await Search(GetCriteria(), new []{p => p.Date, p => p.Description});
