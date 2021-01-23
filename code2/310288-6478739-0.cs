    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
            IQueryable<TEntity> GetAll { get; }
            IEntity GetById(int id) { get; }
    }
    
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IContext context;
        private IObjectSet<TEntity> objectSet;
        public IQueryable<TEntity> GetAll
            {
                get
                {
                    return this.ObjectSet;
                }
            }
    }
