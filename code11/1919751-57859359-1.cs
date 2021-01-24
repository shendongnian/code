	{
		public DbContext()
			: base("name=StudentContext")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}
		public DbSet<Student> Students { get; set; }
	}
