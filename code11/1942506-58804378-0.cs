    public class CustomDbContext : DbContext
    {
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
    		modelBuilder.ApplyConfiguration<UserTypeConfiguration>(new UserTypeConfiguration());
    	}
    }
    
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
    	public void Configure(EntityTypeBuilder<UserType> builder)
    	{
    		builder
    			.HasIndex(c => c.Enum)
    			.IsUnique();
    	}
    }
