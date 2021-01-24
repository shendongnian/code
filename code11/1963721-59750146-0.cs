    var result = (from a in context.Searchstrings
                    where a.Name.Contains("_specific_")
                    select a).ToList().AsQueryable();
    if (searchModel != null)
    {
        if (searchModel.SiteId.HasValue)
            result = result.Where(p => p.Name
                .Split("_specific_", StringSplitOptions.None)[1]
                .Split('_')[0] == searchModel.SiteId);
    }
