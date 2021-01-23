    // Make your DbContext inherit from this. This goes in your Unit of Work.
    public interface IEntitySetProvider : IDisposable
    {
        IEntitySet<T> CreateEntitySet<T>();
    }
    // This is your adapted DBContext
    public class MyDbContext1 : DbContext, IEntitySetProvider
    {
        public IEntitySet<T> CreateEntitySet<T>()
        {
            return new EntitySet<T>(((IObjectContextAdapter)this).CreateObjectSet<T>());
        }
    
        .
        .
        .
    }
    /// <summary>
    ///   A wrapper for an IQueryable that exposes AddNew and Attach methods.
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public interface IEntitySet<T> : IQueryable<T>
    {
        /// <summary>
        ///   Attaches the specified value and considers it new.
        /// </summary>
        /// <param name = "value">The value.</param>
        void AddNew(T value);
        /// <summary>
        ///   Attaches the specified value and considers it modified.
        /// </summary>
        /// <param name = "value">The value.</param>
        void Attach(T value);
    }
    /// <summary>
    ///   An IEntitySet for Entity Framework.
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    internal class EntitySet<T> : IEntitySet<T> where T : class
    {
        private readonly ObjectSet<T> _objectSet;
        public EntitySet(ObjectSet<T> objectSet)
        {
            _objectSet = objectSet;
        }
        #region IEntitySet<T> Members
        public void AddNew(T value)
        {
            _objectSet.AddObject(value);
        }
        public void Attach(T value)
        {
            _objectSet.Attach(value);
            _objectSet.Context.ObjectStateManager.ChangeObjectState(value, EntityState.Modified);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IQueryable<T>) _objectSet).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IQueryable) _objectSet).GetEnumerator();
        }
        public Type ElementType
        {
            get { return ((IQueryable<T>) _objectSet).ElementType; }
        }
        public Expression Expression
        {
            get { return ((IQueryable<T>) _objectSet).Expression; }
        }
        public IQueryProvider Provider
        {
            get { return ((IQueryable<T>) _objectSet).Provider; }
        }
        #endregion
    }
