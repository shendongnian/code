    public class MyEntityDbConfiguration : IEntityTypeConfiguration<MyEntity>
    {
        public void Configure(EntityTypeBuilder<MyEntity> builder)
        {
            builder.Property(e => e.UriField)
                    .HasConversion(v => v.ToString(), v => new Uri(v));
        }
    }
    
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyEntityDbConfiguration());
        }
    }
