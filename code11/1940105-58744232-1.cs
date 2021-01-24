    public static class ApplicationDbContextConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
        public static void Configure(
            DbContextOptionsBuilder<ApplicationDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
