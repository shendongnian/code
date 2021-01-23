    public class EntityBase
    {
        public virtual int Id { get; set; }
    }
    public class Customer : EntityBase
    {
        public virtual string Name { get; set; }
    }
    public class EntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public EntityConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    public class CustomerConfiguration : EntityConfiguration<Customer>
    {
        public CustomerConfiguration()
            : base()
        {
            ...
        }
    }
