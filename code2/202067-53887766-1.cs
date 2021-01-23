 csharp
public async Task<ActionResult> RoleAdd(string UserID)
{
    return View(await 
        UserManager.GetRolesAsync(UserID)).OrderBy(s => s).ToList());
}
There is no need to use `Roles.GetRolesForUser()` and enable the Role Manager Feature.
