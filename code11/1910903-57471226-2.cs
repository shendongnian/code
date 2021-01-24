    public class TestDataContextFactory
    {
      public TestDataContextFactory()
      {
         var builder = new DbContextOptionsBuilder<DataContext>();
         var connection = new SqliteConnection("DataSource=:memory:");
         connection.Open();
         builder.UseSqlite(connection);
         using (var ctx = new DataContext(builder.Options))
         {
            ctx.Database.EnsureCreated();
         }
         _options = builder.Options;
      }
      private readonly DbContextOptions _options;
      public DataContext Create() => new DataContext(_options);
    }
