    public IEnumerable<SelectListItem> GetSelectedBaselines(string meterId)
    {
     IQueryable<SelectListItem> baselines =
    from mlookup in _dbContext.MeterBaselineLookup.AsNoTracking()
    join baseline in _dbContext.MeterBaseline on mlookup.MeterBaselineId equals baseline.Id
    where mlookup.MeterId == Convert.ToInt32(meterId)
    orderby baseline.Id
    select new SelectListItem
    {
      Selected = true,
      Value = baseline.Id.ToString(),
      Text = baseline.Name
    };
    return baselines ;
    }
