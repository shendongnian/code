    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
	{
	    Database.SetInitializer<MyContext>(null);
	}
	public DbSet<BaseClass> Bases { get; set; }
	public DbSet<DerivedClass> Deriveds { get; set; }
	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
	    modelBuilder.Configurations.Add(new BaseConfiguration());
	    modelBuilder.Configurations.Add(new DerivedConfiguration());
	}
    }
