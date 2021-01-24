	{
		public DbContext()
			: base("name=StudentContext")
		{
             this.Configuration.LazyLoadingEnabled = false;
             this.Configuration.ProxyCreationEnabled = false;
		}
		public DbSet<Student> Students { get; set; }
	}
