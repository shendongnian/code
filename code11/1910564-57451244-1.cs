    public class CookContext : DbContext 
    {
        public CookContext(): base("cookContext")
        {
        }
    
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
    		
    	protected override void OnModelCreating(ModelBuilder builder)
        {
    	    builder.Entity<Category>()
                        .HasMany(c => c.Repices)
                        .WithOne(r => r.Recipe)
                        .HasForeignKey(r => r.CategoryId);
    	}
    }
