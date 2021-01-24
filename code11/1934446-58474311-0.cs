cs
// When you're not using the default IdentityRole and IdentityUser class.. 
// you have to change the all of the types IdentityRole and IdentityUser to match those configured in startup.cs.
private readonly RoleManager<IdentityRole> _roleManager;
private readonly UserManager<IdentityUser> _userManager;
public RoleAdminController(RoleManager<IdentityRole> roleManager, 
                           UserManager<IdentityUser> _userManager) 
{
    _roleManager = roleManager;
    _userManager = userManager;
}
Now using `_roleManager` you can say `_roleManager.Roles` and it returns an enumeration of the roles that have been defined in your application.
cs
public async Task<IEnumerable<IdentityRole>> GetRoles() {
    return await _roleManager.Roles;
}
We want to use that enumeration of roles to build a list of users assigned to any role:
cs
public async Task<List<string>> UsersInAnyRole() 
{
    var roles = await GetRoles();
    var usersInAnyRole = new List<string>();
    foreach (var role in roles)
    {
        var usersInRole = await GetUsersAssociatedToRole(role.RoleId);
        if (usersInRole.Count > 0)
        {
            usersInAnyRole.AddRange(usersInRole);
        }
    }
    return usersInAnyRole;
}
public async Task<List<string>> GetUsersAssociatedToRole(string roleId)
{
    var names = new List<string>();
    var role = await _roleManager.FindByIdAsync(roleId);
    if (role != null) 
    {
        foreach (var user in _userManager.Users) 
        {
            if (user != null && await _userManager.IsInRoleAsync(user, role.Name)) 
            {
                names.Add(user.UserName); // Or add user.Id if that works better for your use-case.
            }
        }
    }
    return names;
}
So right now, after calling the UsersInAnyRole() method it will query the database for all the roles. And then use the user manager to return a list of users associated with that particular role. 
Because we're doing this for every role in the application we now end up with a List<string> that contains _all_ of our Users that have _any_ roles associated to them. The only thing remaining is to compare them to a list that contains _all_ of our users' usernames and compare to the list of users that are in roles, to end up with a List<string> that has all the usernames that were not found in our `usersInAnyRole` list.
So we can create two more methods, one for retrieving all the usernames and another for filtering out users that have roles.
cs
public async Task<List<string>> GetAllUserNames()
{
    return await _userManager.Users.Select(user => user.UserName).ToList();
}
// Let's tie it all together.
public async Task<List<string>> UsersWithoutRoles()
{
    var usersInRoles = await UsersInAnyRole();
    var allUserNames = await GetAllUserNames();
    var usersNotInRole = allUserNames.Where(user => !usersInRoles.Any(userInRole => userInRole == user)
    return usersNotInRole;
}
And there you go. Now, if you slightly modify this code to fit your project, you should have a way of finding all the users who are not in any role.
