     public DbQuery<NewEntity> NewEntities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
     modelBuilder.Query<NewEntity>().ToView("NewEntities");
                base.OnModelCreating(modelBuilder);
    }
