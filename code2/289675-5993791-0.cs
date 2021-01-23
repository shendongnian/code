    public IEnumerable<Review.Project> GetProjectsByUser(int userID)
    {
    	var projects = _context.Users
    		.Where(u => u.UserID == userID)
    		.Select(u => u.Projects)
    		.FirstOrDefault();
    
    	return projects != null ? projects : new Review.Project[0];
    }
