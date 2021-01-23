        public interface IPageSpecification
        {
            int CurrentPageIndex { get; }
            int TotalRecordCount { get; }
            int TotalPageCount { get; }        
            int PageSize { get; }
        }   
    
    public interface IPagedList<T> : IPageSpecification
    {
        IEnumerable<T> PageResults { get; }
    }   
