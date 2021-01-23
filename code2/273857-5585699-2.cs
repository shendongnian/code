    public class TLI_FBA : DbContext
    {
    	public DbSet<User> Users { get; set; }
    	public DbSet<UserDetail> UserDetails { get; set; }
    	public DbSet<UserMembership> UserMemberships { get; set; }
    
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
    		modelBuilder.Configurations.Add(new UserConfig());
    		modelBuilder.Configurations.Add(new UserDetailConfig());
    		modelBuilder.Configurations.Add(new UserMembershipConfig());
    	}
    }
