public class SQLite_DbContextFactory : IDesignTimeDbContextFactory<SQLite_DbContext>
    {
        public SQLite_DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLite_DbContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");
            return new SQLite_DbContext(optionsBuilder.Options);
        }
    }
