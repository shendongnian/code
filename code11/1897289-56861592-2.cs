     var results = dbContext.Table1;
    if (sortOrder == "NotFiltered")
    {
        results.where(x => !dbContext.Table2.Select(s => s.Id).Contains(x.Id);
    }
    else
    {
        results.where(x => x.Status != "Pending");
    }
    return results.ToList();
