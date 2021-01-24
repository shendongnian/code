    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    	...
    	
    	modelBuilder.Entity<Entities.BuyGroup>().Property(o => o.Timestamp)
    		.IsRowVersion()
    		.HasDefaultValueSql("CURRENT_TIMESTAMP");
    
    	base.OnModelCreating(modelBuilder);
    }
