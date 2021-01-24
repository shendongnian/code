     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly CrudContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(CrudContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> List()
        {
            return _dbSet.ToList();
        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
