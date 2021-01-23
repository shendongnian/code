    public class ApplicationDbContext : DbContext, IDbContextFactory<DbContext>
    {
        protected static ApplicationDbContext _instance { private set; get; }
        
        private ApplicationDbContext() : base("ApplicationDbContext")
        {
        }
        
        public DbContext Create()
        {
            return getInstance();
        }
        
        
        public static ApplicationDbContext getInstance()
        {
            if (_instance == null) {
                _instance = new ApplicationDbContext();
            }
            return _instance;
        }
    }
