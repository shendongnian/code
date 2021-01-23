    public class BaseType
    {
        public int Id { get; set; }
    }
    public class A : BaseType
    {
        [Column(Name = "Customer")]
        public string Customer { get; set; }
        public string Order { get; set; }
    }
    public class B : BaseType
    {
        [Column(Name = "Customer")]
        public string Customer { get; set; }
        [Column(Name = "Article")]
        public string Article { get; set; }
    }
    public class C : BaseType
    {
        [Column(Name="Article")]
        public string Article { get; set; }
        public string Manufacturer { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<BaseType> BaseTypes { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseType>().ToTable("BaseType");
            modelBuilder.Entity<A>().ToTable("A");
            modelBuilder.Entity<C>().ToTable("C");
            modelBuilder.Entity<B>().ToTable("B");          
        }
    }
