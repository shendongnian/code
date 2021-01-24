    public class Pagination<T>
    {
        public IQueryable<T> Items;
        public int CurrentPageNumber { get; }
        public int PageSize { get; }
        public int StartPage { get; }
        public string Query { get; set; }
        public bool ShowAll { get; set; }
        public int DisplayPages { get; set; } = 5; //Default size
        public int TotalPages { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        
        public Pagination(IQueryable<T> items, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            if (((decimal)DisplayPages % 2) == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(DisplayPages), "Number of pages to render must be odd.");
            }
            Items = items;
            CurrentPageNumber = pageNumber;
            PageSize = pageSize;
            StartPage = 1;
            if (items.Any())
            {
                var rowCount = items.Count();
                TotalPages = (int)Math.Ceiling((decimal)rowCount / PageSize);
            }
            else
            {
                TotalPages = 1;
            }
            
        }
        public IQueryable<T> GetPageData()
        {
            return Items.Skip((CurrentPageNumber - 1) * PageSize).Take(PageSize) ?? new List<T>().AsQueryable();
        }
    }
