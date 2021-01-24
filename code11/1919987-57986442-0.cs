    public bool HasRole(int userId, int roleId)
    {
        MyDbContext newContext = new MyDbContext(...);
	
	    using (newContext)
	    {
		    return newContext.AppUserRoles
			    .Any(x => x.UserId == userId && x.RoleId == roleId);
	    }
    }
