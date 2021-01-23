    interface IKey<TAggregate> : IEquatable<IKey<TAggregate>>
    {
        /* should provide a ctor that accepts a string */
        
        TAggregate GetAggregateType();
        string ToString();
    }
    interface IAggregate<TSelf> where TSelf : IAggregate<TSelf>
    {
        IKey<TSelf> Id { get; }
    }
    interface IRepository<TAggregate> where TAggregate : IAggregate<TAggregate>
    {
        TAggregate Get(IKey<TAggregate> id);
        void Save(TAggregate entity);
        void Remove(TAggregate entity);
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
