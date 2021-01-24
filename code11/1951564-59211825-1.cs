    public class MyRepository : IRepository
    {
      private DbContext _context;
    
      public EFRepository(DbContext context)
      {
          if (context == null)
            throw new ArgumentNullException("context");
    
          _context = context;
      }
    
      public bool Exists()
      {
        return _context.Database.Exists();
      }
      ...
      public IQueryable<T> GetAll<T, TKey>() where T : Entity<TKey>
      {
        return _context.Set<T>();
      }
      public IQueryable<T> GetAllIncluding<T, TKey>(params Expression<Func<T, object>>[] includeProperties) where T : Entity<TKey>
      {
        IQueryable<T> query = _context.Set<T>();
        foreach (var includeProperty in includeProperties)
        {
          query = query.Include(includeProperty);
        }
        return query;
      }
      public IQueryable<T> SearchFor<T, TKey>(Expression<Func<T, bool>> predicate) where T : Entity<TKey>
      {
        return _context.Set<T>().Where(predicate);
      }
      public T GetById<T, TKey>(TKey id) where T : Entity<TKey>
      {
        // use the static Equals method to accept null values
        return _context.Set<T>().FirstOrDefault(x => object.Equals(id, x.Id));
      }
      public void Add<T, TKey>(T entity) where T : Entity<TKey>
      {
        if (entity != null)
        {
          Context.Set<T>().Add(entity);  // new entity
        }
      }
      public void Update<T, TKey>(T entity) where T : Entity<TKey>
      {
        if (entity != null)
        {
          if (object.Equals(entity.Id, default(TKey)))
            Context.Set<T>().Add(entity);  // new entity
          else
            Context.Entry<T>(entity).State = EntityState.Modified;
        }
      }
      public void Save()
      {
        Context.SaveChanges();
      }
      ...
      public void Dispose()
      {
        Dispose(true);
      }
      protected virtual void Dispose(bool disposing)
      {
        if (disposing)
        {
          try
          {
            if (_context != null)
              _context.Dispose();
          }
          catch (Exception ex)
          {
            Debug.WriteLine("MyRepository.Dispose exception:" + ex);
          }
        }
      }
    }
    public class DBUser : Entity<int>
    {
      public MyUser()
      {
        Name = null;
      }
    
      public MyUser(string user)
      { 
        Name = user;
      }
    
      public MyUser(MyUser source) : base(source)
      {
        if (source != null)
        {
          Name = Helpers.SafeCopy(source.Name);
        }
      }
    
      public string Name { get; set; }
    }
