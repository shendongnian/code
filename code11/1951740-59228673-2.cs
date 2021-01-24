    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(UserViewModels userViewModel)
    {
        if (!ModelState.IsValid)
            return View(userViewModel);
        // Get UserManager from OwinContext needs "using Microsoft.AspNet.Identity.Owin;"
        var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var appUser = await userManager.FindByIdAsync(userViewModel.UserId);
        if (appUser == null)
            return await Task.Run<ActionResult>(() => RedirectToAction("UserNotFound", userViewModel));
        appUser.UserName = userViewModel.Username;
        appUser.Email = userViewModel.Email;
        // Updates the user information with UserManager
        await userManager.UpdateAsync(appUser);
        // Get all roles from user.
        var currentUserRoles = await userManager.GetRolesAsync(appUser.Id);
        // Remove all current roles fro this user. You can skip it if you don't need it.
        var removeCurrentRolesResult = await userManager.RemoveFromRolesAsync(appUser.Id, currentUserRoles.ToArray());
        // Verify if any error occours
        if(!removeCurrentRolesResult.Succeeded)
        {
            // Add errors to ModelState.
            removeCurrentRolesResult.Errors.ToList().ForEach(error => ModelState.AddModelError("Role", error));
            return View(userViewModel);
        }
        // get userRoles from text to an array of string;
        var newRoles = userViewModel.Role.Split(',').Select(_ => _.Trim());
        // Adds user to the new role
        var addRoleResult = await userManager.AddToRolesAsync(appUser.Id, newRoles.ToArray());
        if (!addRoleResult.Succeeded)
        {
              // handle errors like removeCurrentRolesResult
              return View(userViewModel);
        }
        return await Task.Run<ActionResult>(() => RedirectToAction("UsersWithRoles"));
    }
