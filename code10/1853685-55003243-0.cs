    public class EFDbContext : DbContext
        {
            public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }
    		protected MainDbContext(DbContextOptions options) : base(options) { }
        }
    	
    public class DimensionsDbContext : EFDbContext
        {
            public DimensionsDbContext(DbContextOptions<DimensionsDbContext> options) : base(options) { }
        }
