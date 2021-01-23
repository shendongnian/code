    public class CustomerConfiguration : EntityConfiguration<Customer>
    {
        public CustomerConfiguration()
            : base()
        {
            ...
            EntityConfiguration.Configure(this);
        }
    }
    public static class EntityConfiguration
    {
        public static void Configure<TEntity>(EntityTypeConfiguration<TEntity> entity) where TEntity : EntityBase
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
