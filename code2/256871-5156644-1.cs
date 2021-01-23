    public interface IPagedList<T> : IList<T>, IPagedList
    {
    }
    public interface IPagedList
    {
        int TotalCount { get; set; }
        int TotalPages { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }
    }
