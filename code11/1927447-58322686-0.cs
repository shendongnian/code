    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
     
        public int PageCount { get; set; }
     
        public int PageSize { get; set; }
     
        public int RowCount { get; set; }
        public string LinkTemplate { get; set; }
     
        public int FirstRowOnPage
        {
     
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
     
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }
     
    public class PagedResult<T> : PagedResultBase
    {
        public IList<T> Results { get; set; }
     
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
    public static class NHibernatePagedResultExtensions
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };
     
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
     
            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();
     
            return result;
        }
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var result = await _session.RunInTransaction(async () =>
        {
            var books = await _session.Books
                                        .Where(b => b.Title.StartsWith("How to"))
                                        .GetPagedAsync(page, pageSize: 25);
            return _mapper.Map<PagedResult<BookModel>>(books);
        });
     
        return View(result);
    }
