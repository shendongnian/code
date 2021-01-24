    class Db : DbContext
    {
        public Db(string constr) : base(constr) { }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .Where(t => t.Namespace == "MyApp.Entities");
    
            foreach (var entityType in entityTypes)
            {
                modelBuilder.RegisterEntityType(entityType);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
