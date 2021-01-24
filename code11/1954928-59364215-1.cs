    public class MyDbContext : DbContext
    {
        public DbQuery<MyEntity> MyEntity { get; set; }
        //... Other tables
    }
