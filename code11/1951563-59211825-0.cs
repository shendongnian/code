    /// <summary>
    /// THE base class for all entities.
    /// </summary>
    /// <typeparam name="TKey">The type of the key for the entity.</typeparam>
    public abstract class Entity<TKey>
    {
      private TKey _id;
    
      public Entity() : this(default(TKey))
      {
      }
    
      public Entity(TKey id)
      {
        _id = id;
      }
    
      public Entity(Entity<TKey> source) : this(default(TKey))
      {
        if (source != null)
        {
          this._id = source._id;
        }
      }
    
      public TKey Id
      {
        get { return _id; }
        set { _id = value; }
      }
    
      public bool IsTransient()
      {
        return Id.Equals(default(TKey));
      }
    }
    public interface IRepository : IDisposable
    {
      bool Exists();
      void OpenConnection(); // helper
      void CreateIfNotExists();  // helper
    
      IQueryable<T> GetAll<T, TKey>() where T : Entity<TKey>;
    
      IQueryable<T> GetAllIncluding<T, TKey>(params Expression<Func<T, object>>[] includeProperties) where T : Entity<TKey>;
    
      IQueryable<T> SearchFor<T, TKey>(Expression<Func<T, bool>> predicate) where T : Entity<TKey>;
    
      T GetById<T, TKey>(TKey id) where T : Entity<TKey>;
      void Add<T, TKey>(T entity) where T : Entity<TKey>;
      void Update<T, TKey>(T entity) where T : Entity<TKey>;
      void Delete<T, TKey>(T entity) where T : Entity<TKey>;
      void Delete<T, TKey>(TKey id) where T : Entity<TKey>;
      void Save();
      void Delete();
    }
