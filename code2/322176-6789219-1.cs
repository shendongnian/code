    var queryOver = session.QueryOver<Shop>()
    						.JoinQueryOver(s => s.Company)
    						.JoinQueryOver<User>(c => c.Users)
    						.Where(u => u.Id == userId);
    
    IEnumerable<T> list = queryOver
                .OrderBy(Projections.Property(sortColumn)).Asc
                .Take(itemsPerPage)
                .Skip(pageNumber * itemsPerPage)
                .Future();
    if (sortDirection == ESortDirection.Descending) list = list.Reverse();
    int totalCount = queryOver.ToRowCountQuery().FutureValue<int>().Value;
    
    return new PagedCollection<T>(list.ToList(), pageNumber, itemsPerPage, totalCount);
