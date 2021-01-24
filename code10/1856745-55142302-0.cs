    public class QueryFilter<TSearchFilter> where TSearchFilter : class
    {
        public QueryFilter()
        {
            SearchFilter = (TSearchFilter)Activator.CreateInstance(typeof(TSearchFilter));
        }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int PageFirstIndex { get; set; }
        public byte PageSize { get; set; }
        public TSearchFilter SearchFilter { get; set; }
    }
    public class QueryFilter : QueryFilter<EmptySearchFilter>
    { }
    public class EmptySearchFilter
    { }
