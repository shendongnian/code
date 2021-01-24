        public class MyDbContext: DbContext
      {
        [Obsolete("This constructor should never be used directly, and is only needed to generate entityframework stuff. Connection string can be adapted as pleased.")]
        public MyDbContext() : base(@"Server=MyServer\Instance;Database=MyDatabase;Trusted_Connection=True;")
        {
    
        }
    
        public MyDbContext(string connectionString) : base(connectionString)
        {
          Database.CreateIfNotExists();
          Database.SetInitializer(new MigrateDatabaseToLatestVersion<StratonLocalizerDatabase, Migrations.Configuration>());
          Database.Initialize(false);
        }
