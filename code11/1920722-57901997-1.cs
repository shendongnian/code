    public IQueryable<UserModel> ShowallRoles(string sortColumn, string sortColumnDir, string Search)
    {
    	var result = (from AssignedRoles in db.AssignedRoles
    				 join registration in db.Registration on AssignedRoles.RegistrationID equals registration.RegistrationID
    				 join AssignedRolesAdmin in db.Registration on AssignedRoles.AssignToAdmin equals AssignedRolesAdmin.RegistrationID
    				 select new UserModel
    				 {
    					 Name = registration.Name,
    					 AssignToAdmin = string.IsNullOrEmpty(AssignedRolesAdmin.Name) ? "*Not Assigned*" : AssignedRolesAdmin.Name.ToUpper(),
    					 RegistrationID = registration.RegistrationID
    				 });
    	
    	if (!string.IsNullOrEmpty(Search))
    	{
    		result = result.Where(m => m.Name == Search);
    	}		
    	
    	if (!string.IsNullOrEmpty(sortColumn))
    	{
    		if (!string.IsNullOrEmpty(sortColumnDir))
    		{
    			if(sortColumnDir == "asc")
    				result = result.OrderBy(sortColumn);
    			else
    				result = result.OrderByDescending(sortColumn);
    		}
    	}
    	return result;
    }
