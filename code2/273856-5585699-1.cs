    public class UserConfig : EntityConfiguration<User>
    {
    	public UserConfig()
    	{
    		this.MapSingleType(user => new
    		{
    			UserId = user.UserId,
    			UserName = user.UserName
    		}).ToTable(new StoreTableName("aspnet_Users", "dbo"));
    	}
    }
    
    public class UserDetailConfig : EntityConfiguration<UserDetail>
    {
    	public UserDetailConfig()
    	{
    		this.HasKey(u => u.UserId);
    		this.MapSingleType(ud => new
    		{
    			UserId = ud.UserId,
    			FullName = ud.FullName,
    			CompanyName = ud.CompanyName
    		}).ToTable(new StoreTableName("UserDetail", "dbo"));
    	}
    }
    
    public class UserMembershipConfig : EntityConfiguration<UserMembership>
    {
    	public UserMembershipConfig()
    	{
    		this.HasKey(m => m.UserId);
    
    		this.MapSingleType(membership => new
    		{
    			UserId = membership.UserId,
    			Password = membership.Password,
    			Email = membership.Email,
    			IsApproved = membership.IsApproved,
    			IsLockedOut = membership.IsLockedOut
    		}).ToTable(new StoreTableName("aspnet_Membership", "dbo"));
    	}
    }
