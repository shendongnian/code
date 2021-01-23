    public async Task<ActionResult> RoleAdd(string UserID)
    {
    List<string> UserRoles = (await UserManager.GetRolesAsync(UserID))
                                 .OrderBy(s => s).ToList();
    
    return View(UserRoles)
    }
