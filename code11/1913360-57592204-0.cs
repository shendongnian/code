    protected override void OnModelCreating(ModelBuilder builder)
    {
            base.OnModelCreating(builder);
            
    }
    public DbSet<YourModelName> YourModelNamePlural { get; set; }
