      // DB Context
    
        public class DatabaseContext : DbContext
        {
            string _dbPath;
    
            public DbSet<Participant> Participants { get; set; }
    
            public DatabaseContext(string dbPath)
            {
                _dbPath = dbPath;
    
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"Filename={_dbPath}");
            }
        }
