    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Map(m =>
        {
            m.MapInheritedProperties();
            m.ToTable("People");
        });
 
        modelBuilder.Entity<Person_Archieve>().Map(m =>
        {
            m.MapInheritedProperties();
            m.ToTable("People_Archieve");
        });            
    }
