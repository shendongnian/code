    public class TestRepository<TContext, T> : ITestRepository<TContext,T> 
        where TContext : DbContext
        where T : BaseEntity
    {
        
        private readonly TContext _context;
        private DbSet<T> entities;
       
        public TestRepository(TContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
     
     
        public List<T> GetAll()
        {
           
            return entities.AsNoTracking().ToList();
        }
    }
