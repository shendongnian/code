    public async Task Search(
       Expression<Func<T, bool>> criteria, 
       Func<T, object> mainOrder, 
       params Func<T, object>[] subOrders)
    {
        var elems = await Service.SearchAsync(criteria, false);
        var sorted = elems.AsEnumerable().OrderBy(mainOrder);
        foreach(var subOrder in subOrders){
          sorted = sorted.ThenBy(subOrder);
        }
        Searchlist.AddRange(sorted)
    }
    await Search(GetCriteria(), p => p.Date, p => p.Description);
