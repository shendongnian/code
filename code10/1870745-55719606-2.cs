C#
var umpireUserRole = 
	_roleService.GetRoleByName(roleName) 
	?? new UserRole
		{
			Name = UserRole.Umpire,
			Users = new HashSet<User>()
		};
umpireUserRole.Users.Add(user);
user.Roles = new HashSet<UserRole> { umpireUserRole };
_roleService.SaveRole(umpireUserRole);
