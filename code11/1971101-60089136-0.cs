protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<YourEntity>()
        .Property(b => b.Timezone)
        .HasDefaultValueSql("Eastern Time Zone");
}
