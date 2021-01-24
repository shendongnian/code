    var query = _context.Companies;
    if (!string.IsNullOrEmpty(paging.SearchCriteria.companyNameFilter))
      query = query.Where(c => c.CompanyName.Contains(paging.SearchCriteria.companyNameFilter));
    if (!string.IsNullOrEmpty(paging.SearchCriteria.companyNumberFilter))
      query = query.Where(c => c.CompanyNumber.StartsWith(paging.SearchCriteria.companyNumberFilter));
    // etc. for the rest of the query
