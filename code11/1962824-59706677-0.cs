        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablexxx>();
            base.OnModelCreating(modelBuilder);
        }
        public class Lookup
        {
            public DbSet<Tablexxx> Tablexxx{ get; set; }
        }
        public Lookup Lookups { get; } = new Lookup();
