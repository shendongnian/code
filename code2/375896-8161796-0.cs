    class MyDbContext : DbContext
    {
    	public IDbSet<User> Users { get; set; }
    	
    	public IQueryable<User> Admins 
    	{
    		get 
    		{
    			return from user in users
    				   where user.Role == "admin"
    				   select user;
    		}
    	}
    }
