    public class BaseConfiguration : EntityTypeConfiguration<BaseClass>
    {
        public BaseConfiguration()
	{
	    HasKey(k => k.Id);
	    Property(p => p.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
	}
    }
    public class DerivedConfiguration : BaseConfiguration
    {
        public DerivedConfiguration()
	{
	    Property(p => p.Id).HasColumnName("BaseClassId");
	}
    }
