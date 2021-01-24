    public class MyServiceFactory
    {
        private readonly AppDbContext appDbContext;
        public MyServiceFactory(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    
        public MyService Create() => new MyService(appDbContext);
    }
