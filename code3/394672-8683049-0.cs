    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>().ToTable("DBA_APPLICATIONS");
        // otherwise EF assumes the table is called "Applications"
    }
