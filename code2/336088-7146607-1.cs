    public class MyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CurrencyConfiguration());           
        }
    }
