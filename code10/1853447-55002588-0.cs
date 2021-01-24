    public class ABFContext : DbContext
    {
        public ABFContext() : base("ABFDatabase")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ABFContext>());
            Database.Initialize(true);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
    }
