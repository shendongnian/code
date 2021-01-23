    public class PaginationData
    {
        private System.Web.Routing.RouteValueDictionary _RouteValues;
        public System.Web.Routing.RouteValueDictionary RouteValues
        {
            get
            {
                if (_RouteValues == null)
                {
                    _RouteValues = new System.Web.Routing.RouteValueDictionary();
                }
                return _RouteValues;
            }
            private set { _RouteValues = value; }
        }
        public void SetRouteValues(object routeValues)
        {
            this.RouteValues = new System.Web.Routing.RouteValueDictionary(routeValues);
        }
        public bool HasPreviousPage { get { return (PageIndex > 1); } }
        public bool HasNextPage { get { return (PageIndex < TotalPages); } }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public PaginationData(int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
    }
