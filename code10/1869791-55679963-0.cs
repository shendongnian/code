    public virtual async Task<ActionResult<List<User>>> GetuserList(CancellationToken cancellationToken)
    {
        var userDto = new UserDto();
        var users = await userManager.Users.Include(x => x.UserRoles).ThenInclude(t=>t.Role)
           .Select(x => new UserDto
            {
                UserName = x.UserName,
                Email = x.Email,
                Family = x.Family,
                Name = x.Name,
                Password = x.PasswordHash,
                PhoneNumber = x.PhoneNumber,
                RoleId = x.UserRoles.FirstOrDefault(t => t.UserId == x.Id).UserId
            })
          .ToListAsync();
    
        return users;
    }
