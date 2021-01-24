    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context object for the database
        /// </summary>
        private DbContext _context;
        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        private DbSet<TEntity> _dbSet;
        /// <summary>
        /// Initializes a new instance of the GenericRepository class
        /// </summary>
        /// <param name="context">The Entity Framework ObjectContext</param>
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet;
        }
        /// <summary>
        /// Gets all records as an IQueryable and disables entity tracking
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public IQueryable<TEntity> AsNoTracking()
        {
            return _dbSet.AsNoTracking<TEntity>();
        }
        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }
        /// <summary>
        /// Finds a record with the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where<TEntity>(predicate);
        }
        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            return _dbSet.FindAsync(keyValues);
        }
        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Single<TEntity>(predicate);
        }
        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.First<TEntity>(predicate);
        }
        /// <summary>
        /// The first record matching the specified criteria or null if not found
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria or a null object if nothing was found</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault<TEntity>(predicate);
        }
        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Remove(entity);
        }
        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Add(entity);
        }
        /// <summary>
        /// Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }
        /// <summary>
        /// Detaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Detach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
        public void MarkModified(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public DbEntityEntry<TEntity> GetEntry(TEntity entity)
        {
            return _context.Entry(entity);
        }
        /// <summary>
        /// Saves all context changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
