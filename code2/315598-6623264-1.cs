    public DbSet<Part> Parts { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Part>().Ignore(e => e.PartNumber);
        
        
        base.OnModelCreating(modelBuilder);
    }
