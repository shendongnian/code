		public class CMSModels : DbContext
		{
          //public DbSet<ContentTypeModel> ContentType { get; set; }
          //public DbSet<LayoutModel> Layout { get; set; }
          //public DbSet<PageModel> Page { get; set; }
          //public DbSet<PageZoneModel> PageZone { get; set; }
          public DbSet<Sites> Site { get; set; }
          //public DbSet<ZoneContentModel> ZoneContent { get; set; }
          //public DbSet<ZoneTypeModel> ZoneType { get; set; }
		  
		  protected override void OnModelCreating(ModelBuilder modelBuilder)
		  {
			  base.OnModelCreating(modelBuilder);
			  modelBuilder.Entity<Sites>().Property(r => r.SiteID) 
                           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		  }
		}
