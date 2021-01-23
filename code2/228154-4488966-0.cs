    IQueryable<Publication> pubs = GetPubs();
    pubs = ApplySort(pubs, SortBy);
    pubs = GetPage(pubs, PageSize, Page);
     
    private IQueryable<Publication> GetPage(IQueryable<Publication> pubs, int PageSize, int Page)
    {
       return pubs.Skip(PageSize * (Page - 1)).Take(PageSize);
    }
    private IQueryable<Publication> ApplySort(IQueryable<Publication> pubs, string SortBy)
    {
     switch (SortBy)
      {
       case "Latest": return pubs.OrderByDescending(p => p.Posted);
                      break;
       default: return pubs.OrderByDescending(p => p.Posted);
                break;
      }
    }
