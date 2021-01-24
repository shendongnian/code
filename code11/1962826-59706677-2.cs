        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablexxx>();
            base.OnModelCreating(modelBuilder);
        }
        public class Lookup
        {
            Db db;
            public Lookup(Db db)
            {
                this.db = db;
            }
            public DbSet<Tablexxx> CreditAccounts => db.Set<Tablexxx>();
        }
        public Lookup Lookups => new Lookup(this);
