    public Task<List<AppUser>> GetAvailableUsers()
    {
        return _dbContext.AppUser
                .Include(x => x.Roles)
                .Where(x => x.IsActive && x.Roles.Select(y => y.RoleId).Contains(3))
                .ToListAsync();
    }
    
