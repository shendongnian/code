    public class ViewContext : DbContext
    {
        public string DefaultConnectionStringName { get; set; }
        public string ConnectionString { get; set; }
        public DbSet<MaxTradeDate> MaxTradeDate { get; set; }
        public DatabaseContext()
        {
            DefaultConnectionStringName = "DatabaseContext";
        }
        public DatabaseContext
        (
            string defaultConnectionStringName,
            string connectionString = ""
        )
        {
            DefaultConnectionStringName = defaultConnectionStringName;
            ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(new ConnectionStringManager().Get(DefaultConnectionStringName));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
