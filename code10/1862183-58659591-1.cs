    public class TlInMemoryDbContext : TlDbContext
    {
        public TlInMemoryDbContext(DbContextOptions<TlDbContext> options)
            : base(options)
        { }
        Dictionary<Type, IQueryable> queries = new Dictionary<Type, IQueryable>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Query<EffectiveTimeEntry>().ToFakeQuery(queries);
        }
        public void SetQuery<T>(IQueryable<T> query)
        {
            lock (queries)
                queries[typeof(T)] = query;
        }
    }
