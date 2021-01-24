	{
		public DbContext()
			: base("name=StudentContext")
		{
             this.Configuration.LazyLoadingEnabled = true;
             this.Configuration.ProxyCreationEnabled = true;
		}
		public DbSet<Student> Students { get; set; }
	}
