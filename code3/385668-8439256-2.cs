    public Collection<CustomType> GetAll(GetAllCriteria criteria)
    {
        var query = dbContext.CustomTypes.AsQueryable();
    
        // some code
    
        // apply order by
        if (criteria.ToBeOrderedBy != null && criteria.ToBeOrderedBy.Count > 0)
        {
            var firstOrderBy = criteria.ToBeOrderedBy.First();
            query = firstOrderBy.Value
                ? query.OrderBy(firstOrderBy.Key)
                : query.OrderByDescending(firstOrderBy.Key);
    
            query = criteria.ToBeOrderedBy.Skip(1).Aggregate(query, 
                (lastOrderBy, nextOrderBy) => nextOrderBy.Value
                ? ((IOrderedQueryable<CustomType>)lastOrderBy)
                    .ThenBy(nextOrderBy.Key)
                : ((IOrderedQueryable<CustomType>)lastOrderBy)
                    .ThenByDescending(nextOrderBy.Key));
        }
    
        // some more code
    
        var results = query.ToList();
        return results;
    }
