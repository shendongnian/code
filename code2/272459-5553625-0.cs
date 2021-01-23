    public class YourDbContext : DbContext
	{
		public IDbSet<SomeObject> SomeObjects { get; set; }
		public IDbSet<SomeOtherObject> SomeOtherObjects { get; set; }
		public IDbSet<YetAnotherObject> YetMoreObjects { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new RuntimeSchemaConfiguration<SomeObject>());
			modelBuilder.Configurations.Add(new RuntimeSchemaConfiguration<SomeOtherObject>());
			modelBuilder.Configurations.Add(new RuntimeSchemaConfiguration<YetAnotherObject>());
		}
		private class RuntimeSchemaConfiguration<T> : EntityTypeConfiguration<T>
			where T : class
		{
			public RuntimeSchemaConfiguration()
			{
				// Rename the schema based on a string
				// from a config file or other source
				var schemaName = GetSchemaNameFromConfigFile();
				ToTable(typeof(T).Name, schemaName);
			}
		}
	}
