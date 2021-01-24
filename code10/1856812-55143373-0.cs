    public class QueryFilter 
    { 
        public string SortBy { get; set; }
        public int PageFirstIndex { get; set; }
        public byte PageSize { get; set; }
    }
    
    public class QueryFilter<TSearchFilter> : QueryFilter 
        where TSearchFilter : class, new() 
    {
        public QueryFilter()
        {
            SearchFilter = new TSearchFilter();
        }
        public TSearchFilter SearchFilter { get; set; }
    }
