	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Student>()
					.HasOptional(s => s.Siblings) // Mark Siblings property optional in Student entity
					.WithRequired(ad => ad.Student); // mark Student property as required in Siblings entity. Cannot save Siblings without Student
	}
