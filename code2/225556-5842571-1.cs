    public class SiteDataContext : DbContext
    	{
    		public DbSet<Blog> Blogs { get; set; }
    		public DbSet<BlogFeedback> BlogFeedbacks { get; set; }
    		public DbSet<BlogCategoryList> BlogCategoryLists { get; set; }
    		public DbSet<BlogCategory> BlogCategories { get; set; }
    
    		protected override void OnModelCreating(ModelBuilder modelBuilder)
    		{
    			modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
    			base.OnModelCreating(modelBuilder);
    		}
    	}
