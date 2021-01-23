    IQueryable<Partners> recs = contextApi.Partners;
    if (status != -1)
    {
       recs = recs.Where(i => i.Status == status);
    }
    recs = recs.OrderBy(i => i.Status).ThenBy(i => i.CompanyName);
    foreach (var rec in recs)
    {
    }
