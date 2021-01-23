    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    	modelBuilder.Entity<SomeEntity>()
    		.Property(p => p.RowVersion).IsConcurrencyToken();
    	base.OnModelCreating(modelBuilder);
    }
	public override int SaveChanges()
	{    
		var objectContextAdapter = this as IObjectContextAdapter;
		if (objectContextAdapter != null) {
			objectContextAdapter.ObjectContext.DetectChanges();
			foreach (ObjectStateEntry entry in objectContextAdapter.ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified)) {
				var v = entry.Entity as IVersionedRow;
				if (v != null) 
					v.RowVersion++;
			}
		}
		return base.SaveChanges();
	}
