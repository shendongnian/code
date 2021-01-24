    var users = userManager.Users.Select(x => new 
    {
        UserName = x.UserName,
        Email = x.Email,
        Family = x.Family,
        Name = x.Name,
        Password = x.PasswordHash,
        PhoneNumber = x.PhoneNumber,
        Role = x.UserRoles.Select(r => new { r.RoleId, r.Role.RoleName}).FirstOrDefault()
    }).ToList()
    .Select(x => new UserDto
    {
        UserName = x.UserName,
        Email = x.Email,
        Family = x.Family,
        Name = x.Name,
        Password = x.PasswordHash,
        PhoneNumber = x.PhoneNumber,
        RoleId = x.Role.RoleId,
        RoleName = x.Role.RoleName
    }).ToList();
       
