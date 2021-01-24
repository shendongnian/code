    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionstring)
        {
        } 
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //get the dynamic table prefix...
            var myAppPrefix = "user1";
            modelBuilder.Conventions.Add(new CustomTableNameConvention(myAppPrefix));
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<SomeModel> { get; set; }
        ...
    }
