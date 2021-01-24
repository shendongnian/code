protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<RegionLanguage>(builder =>
    {
        builder.HasQueryFilter(rl => rl.CultureCode == "en-US");
    });
}
