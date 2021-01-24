    private IQueryable<User> Get_internal(UserFilter filter)
            {
                IQueryable<User> users = _context.Users;
    
                if (filter.Deleted != null)
                {
                    users = users.Where(u => u.Deleted == filter.Deleted );
                }            
    
                return users.Select(x => new User() {
                    Id = x.Id,
                    Name = x.Name,
                    //every property except your image property
                    });
            }
