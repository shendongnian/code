	class MyDbContext : DbContext { 
		public virtual DbSet<Permissions> Permissions {get;set;}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Permissions>().HasKey(p => new { p.EmployeeName, p.StoreId});
		}
	}
	
