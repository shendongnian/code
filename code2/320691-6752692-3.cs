		public class MyDbContext : DbContext
		{
		  public DbSet<Sites> Sites { get; set;}
		  // other properties
		  
		  protected override void OnModelCreating(ModelBuilder modelBuilder)
		  {
			  base.OnModelCreating(modelBuilder);
			  modelBuilder.Entity<Sites>().Property(r => r.SiteID) 
                           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		  }
		}
