    public interface IPagedList
    {
        int CurrentPageIndex { get; }
        int TotalRecordCount { get; }
        int TotalPageCount { get; }        
        int PageSize { get; }
        Type ElementType { get; }
        IEnumerable PageResults { get; }
    }   
    public interface IPagedList<T> : IPagedList
    {
        new IEnumerable<T> PageResults { get; }
    }  
