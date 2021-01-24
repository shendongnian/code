    public class DbContextFactory
    {
        public YourDbContext Create()
        {
            var options = new DbContextOptionsBuilder<YourDbContext>()
                .UseSqlServer(_connectionString)
                .Options;
            return new YourDbContext(options);
        }
    }
