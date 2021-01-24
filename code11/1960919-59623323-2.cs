    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreDto> StoreDtos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoreDtos>(sd =>
        {
            sd.HasNoKey().ToView(null);
        });
    }
