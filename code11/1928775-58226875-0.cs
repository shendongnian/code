    public class Db : DbContext
    {
        private IMemoryCache _memoryCache;
        public Db(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public class EntityCache
        {
            private Db db;
            public EntityCache(Db customDBContext)
            {
                this.db = customDBContext;
            }
            public IQueryable<LK_ProductType> LK_ProductTypes => db._memoryCache.GetOrCreate<IList<LK_ProductType>>("LK_ProductTypeMemoryCache",f => db.LK_ProductTypes.AsNoTracking().ToList()).AsQueryable();
        }
        public EntityCache Cache => new EntityCache(this);
      
        public DbSet<LK_ProductType> LK_ProductTypes { get; set; }
        
    }
