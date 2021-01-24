     public class GenericRepository<TEntity> where TEntity : class
    {
        internal BlogContext blogContextlog;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(BlogContext context)
        {
            this.blogContextlog = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = blogContextlog.Set<TEntity>().ToList();
        }
        public virtual TEntity GetByID(object id)
        {
            return blogContextlog.Find(id);
        }
    }
