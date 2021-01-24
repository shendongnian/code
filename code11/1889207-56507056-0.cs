    public class YourDomainRepository
    {
        private readonly YourDbContext _context;
    
        public YourDomainRepository(YourDbContext context)
        {
            _context = context;
        }
    
        ...Other repository methods
    }
