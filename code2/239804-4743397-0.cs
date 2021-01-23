    interface IKey<T> : IEquatable<IKey<T>>
    {
        /* should provide a ctor that accepts a string */
        T GetKeyType();
        string ToString();
    }
    interface IAggregate<T> where T : IAggregate<T>
    {
        IKey<T> Id { get; }
    }
    interface IRepository<TEntity> where TEntity : IAggregate<TEntity>
    {
        TEntity Get(IKey<TEntity> id);
        void Save(TEntity entity);
        void Remove(TEntity entity);
    }
    class User : IAggregate<User>
    {
        public IKey<User> Id { get; private set; }
    }
    class Blog : IAggregate<Blog>
    {
        public IKey<Blog> Id { get; private set; }
        public IKey<User> Author { get; private set; }
    }
