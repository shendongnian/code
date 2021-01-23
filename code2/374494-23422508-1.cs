     /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        #endregion
        #region Ctor
        public EfRepository(IDbContext context)
        {
            this._context = context;
            this.AutoCommitEnabled = true;
        }
        #endregion
        #region interface members
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        public T Create()
        {
            return this.Entities.Create();
        }
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this.Entities.Add(entity);
            if (this.AutoCommitEnabled)
                _context.SaveChanges();
        }
        public void InsertRange(IEnumerable<T> entities, int batchSize = 100)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                if (entities.HasItems())
                {
                    if (batchSize <= 0)
                    {
                        // insert all in one step
                        entities.Each(x => this.Entities.Add(x));
                        if (this.AutoCommitEnabled)
                            _context.SaveChanges();
                    }
                    else
                    {
                        int i = 1;
                        bool saved = false;
                        foreach (var entity in entities)
                        {
                            this.Entities.Add(entity);
                            saved = false;
                            if (i % batchSize == 0)
                            {
                                if (this.AutoCommitEnabled)
                                    _context.SaveChanges();
                                i = 0;
                                saved = true;
                            }
                            i++;
                        }
                        if (!saved)
                        {
                            if (this.AutoCommitEnabled)
                                _context.SaveChanges();
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            if (this.AutoCommitEnabled)
            {
                _context.SaveChanges();
            }
            else
            {
                try
                {
                    this.Entities.Attach(entity);
                    InternalContext.Entry(entity).State = System.Data.EntityState.Modified;
                }
                finally { }
            }
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            if (InternalContext.Entry(entity).State == System.Data.EntityState.Detached)
            {
                this.Entities.Attach(entity);
            }
            this.Entities.Remove(entity);
            if (this.AutoCommitEnabled)
                _context.SaveChanges();
        }
        
        public IDbContext Context
        {
            get { return _context; }
        }
        public bool AutoCommitEnabled { get; set; }
        #endregion
        #region Helpers
        protected internal ObjectContextBase InternalContext
        {
            get { return _context as ObjectContextBase; }
        }
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities as DbSet<T>;
            }
        }
        #endregion
    }
