    public IEnumerable<UserRoleIndicator> GetRoleIndicators(string userName)
    {
    	var roles = _roleProvider.GetAllRoles();
    	var userRoles = _roleProvider.GetRolesForUser(userName);
    	
    	return roles.Select(role => new UserRoleIndicator 
    	{ 
    		RoleName = role,
    		InRole = userRoles.Any(userRole => role == userRole) 
    	});	
    }
