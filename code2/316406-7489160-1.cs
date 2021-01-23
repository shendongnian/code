    public partial class MyDb: DbContext
    {
        public static string Connection
        {
            get
            {
                var result = new SqlCeConnectionStringBuilder();
                result["Data Source"] = "MyDatabaseFile.sdf";
                
                return result.ToString();
            }
        }
        public MyDb()
            : base(Connection)
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    
        public DbSet<MyTable> MyTable { get; set; }
    }
