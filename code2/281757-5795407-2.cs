    public abstract class BaseRepository<T> : IRepository<T> where T : IDataEntity
    {
        protected IRepository<T> Repository { get; set; }
        public BaseRepository()
        {
            Repository = ObjectFactory.GetInstance<IRepository<T>>();
        }
        public virtual IQueryable<T> GetQuery()
        {
            return Repository.GetQuery();
        }
        public virtual IQueryable<T> GetQuery(params Expression<Func<T, object>>[] includes)
        {
            return Repository.GetQuery(includes);
        }
        public virtual void Insert(T entity)
        {
            Repository.Insert(entity);
        }
        public virtual void Update(T entity)
        {
            Repository.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
        }
        public virtual void Attach(T entity)
        {
            Repository.Attach(entity);
        }
    }
