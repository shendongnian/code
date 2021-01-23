    public class MyClass
    {
        public int Id { get; set; }
        public string P1 { get; set; }
        // ... properties P2 to P49, all of type string
        public string P50 { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<MyClass> MyClassSet { get; set; }
    }
