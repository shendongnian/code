    public Task<List<AppUser>> GetAvailableUsers()
    {
        return _dbContext.AppUser
                .Include(x => x.Roles)
                .Where(x => x.IsActive && x.Role == 3)
                .ToListAsync();
    }
    
