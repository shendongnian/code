    public interface IApplicationDbContext
    {
        //Identity Management
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
       
        DbSet<U> Set<U>() where T: class; //get DataSets
        int SaveChanges(); //save the changes
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        
        protected GenericRepository(IApplicationDbContext context)
        {
            _dbContext = context;
        }
        private IApplicationDbContext _dbContext;
        private static IEnumerable<T> entity;
        public IEnumerable<T> Get(bool forceRefresh = false)
        {
            if (forceRefresh || entity == null)
                entity = _dbContext.Set<T>();
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
