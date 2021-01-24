	{
		public DbContext()
			: base("name=StudentContext")
		{
			this.Configuration.LazyLoadingEnabled = true;
		}
		public DbSet<Student> Students { get; set; }
	}
