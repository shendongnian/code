    public virtual DbQuery<MyEntity> MyEntities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        const string SQL = "SELECT whatever FROM wherever";
        modelBuilder.Query<MyEntity>().ToQuery(() => MyEntities .FromSql(SQL).AsQueryable());
    [...]
