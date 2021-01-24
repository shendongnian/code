    public class Service
    {
        private readonly DbContextFactory _dbContextFactory;
        public Service(DbContextFactory dbContextFactory) 
             => _dbContextFactory = dbContextFactory;
        public void Execute()
        {
            using (var context = _dbContextFactory.Create())
            {
                // use context
            }
        }
    }    
