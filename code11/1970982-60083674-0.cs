    public async Task<User> GetUser(Guid userId)
    {
    	return await RepositoryContext.Users
    		.Include(x => x.UserPrivileges).ThenInclude(x => x.Privilege)
    		.Where(x => x.UserPrivileges.Any(p => p.IsDeleted)) 
    		.FirstOrDefaultAsync(x => x.Id == userId);
    }
