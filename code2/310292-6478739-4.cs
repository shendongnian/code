    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
            IQueryable<TEntity> GetAll { get; }
            IEntity GetById(int id) { get; }
    }
    
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IContext context;
        private IObjectSet<TEntity> objectSet;
    
    private IObjectSet<TEntity> ObjectSet
    {
            get
            {
                if (this.objectSet == null)
                {
                    var entitySetProperty = this.Context.GetType().GetProperties().Single(p => p.PropertyType.IsGenericType && typeof(IQueryable<>).MakeGenericType(typeof(TEntity)).IsAssignableFrom(p.PropertyType));
    
                    this.objectSet = (IObjectSet<TEntity>)entitySetProperty.GetValue(this.Context, null);
                }
    
                return this.objectSet;
            }
    }
        public IQueryable<TEntity> GetAll
            {
                get
                {
                    return this.ObjectSet;
                }
            }
    }
