    public abstract class BaseMap<T, U> : IEntityTypeConfiguration<T> where T: BaseEntity<U>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
    public abstract class ChildBaseMap<T, U> : BaseMap<T, U> where T: ChildBaseEntity<U>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)//<== virtual is wrong here as I need to override the parent Configure
        {
            base.Configure(builder);
            builder.Property(x => x.BaseId).IsRequired();
        }
    }
    public class PersonMap : ChildBaseMap<Person, int>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
          ....
