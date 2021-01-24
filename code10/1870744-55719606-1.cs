C#
var umpireUserRole = 
	_roleService.GetRoleByName(roleName) 
	?? new UserRole
		{
			Name = UserRole.Umpire,
			Users = new HashSet<User>()
		};
umpireUserRole.Users.Add(user); //Fix Parentheses from Bracket
user.Roles = new HashSet<UserRole> { umpireUserRole };
_roleService.SaveRole(umpireUserRole);
