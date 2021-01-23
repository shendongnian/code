    public DbSet<Person> List { get; set; }
    public string tablename = "list";
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .ToTable(tablename)
            .HasKey(s => s.NameId);
    }
