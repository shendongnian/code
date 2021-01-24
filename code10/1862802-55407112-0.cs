    public class MyDbContext : DbContext
    {
        public MyDbContext() 
            : base("ApplicationDatabase")
        { }
     
        public MyDbContext(string connectionString) 
            : base(connectionString)
        { }
    }
