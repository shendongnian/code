        public interface IPagedListDetails
        {
            int CurrentPageIndex { get; }
            int TotalRecordCount { get; }
            int TotalPageCount { get; }
            int PageSize { get; }
        }
    
        public interface IPagedList<T> : IPagedListDetails
        {
            IEnumerable<T> PageResults { get; }
        }
