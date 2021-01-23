    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total/pageSize;
            if (total%pageSize > 0)
                TotalPages++;
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index*pageSize).Take(pageSize).ToList());
        }
        public PagedList(IEnumerable<T> source, int total, int index, int pageSize)
        {
            this.TotalCount = total;
            this.TotalPages = total/pageSize;
            if (total%pageSize > 0)
                TotalPages++;
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source);
        }
        #region IPagedList<T> Members
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool IsPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool IsNextPage
        {
            get { return (PageIndex*PageSize) <= TotalCount; }
        }
        #endregion
    }
