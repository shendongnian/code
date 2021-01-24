    public class NewsRepository : INewsRepository
    {
        private readonly BmuContext _context;
        private readonly IMemoryCache _memoryCache;
        public NewsRepository(BmuContext context, IMemoryCache memoryCache)
        {
            _context = context;
        }
        //...
    }
