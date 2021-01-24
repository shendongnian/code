`
[Flags]
public enum Permissions
{
    None = 0,
    Registered = 1 << 0,
    SuperAdmin = 1 << 1,
    Manager = 1 << 2,
    // Etc...
}
`
Using this you can then use this method on the user to determine which roles are allowed:
`
public bool IsInRole(Permissions roles)
{
    var rolesToCheck = roles.GetFlags().Where(p => p != RolePermissions.None);
    return rolesToCheck.Any(role => Roles.HasFlag(role));
}
`
and:
`
if(User.IsInRole(Permissions.SuperAdmin | Permissions.Manager)
{
    // Do something
}
`
Similarly you can also add this to the attribute by creating a custom extension of the Authorize attribute:
`
public class CustomAuthorize : ActionFilterAttribute, IActionFilter
{
    public Permissions Roles { get; set; }
    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    {
        bool authorized = false;
        var roleFlags = Roles.GetFlags();
        if (!roleFlags.All(r => r == RolePermissions.None))
        {
            foreach (var role in roleFlags.Where(p => p != RolePermissions.None))
            {
                if (maritimeUser.Roles.HasFlag(role))
                {
                    authorized = true;
                }
            }
        }
    if(!authorized)
    {
        //Send to unauthorized page or throw exception
    }
    }
}
`
and use by
`
[CustomAuthorize(Roles = Permissions.SuperAdmin | Permissions.Manager)]
`
