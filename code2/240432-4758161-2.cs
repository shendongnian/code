    foreach (var filterForeach in filters)
    {
        var filter = filterForeach;  // for the lambdas
        switch (filter.Key)
        {
            case FilterType.Customer:
                jobQuery = jobQuery.Where(x => x.KUNDREF != null &&
                           x.KUNDREF.ToLower().Contains(filter.Value.ToLower()));
                break;
    
            case FilterType.Name:
                jobQuery = jobQuery.Where(x => x.JOBBESKR != null &&
                           x.JOBBESKR.ToLower().Contains(filter.Value.ToLower()));
                break;
        }
    }
