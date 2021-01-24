    public abstract class BaseContext : DbContext
    {
        public BaseContext(DbContext options)
        : base(options)
        { }
        public DbSet<object> FirstDbSet { get; set; }
        ...
    }
