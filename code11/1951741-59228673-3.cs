    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromService] UserManager userManager, UserViewModels userViewModel)
    {
        if (!ModelState.IsValid)
            return View(userViewModel);
        var userModel = await userManager.FindByIdAsync(userViewModel.Id);
        if(userModel == null)
        {
            return await Task.Run<ActionResult>(() => RedirectToAction("UserNotFound", userViewModel));
        }
        
        // Updates the user information with UserManager
        userManager.SetUserNameAsync(userModel, userViewModel.UserName);
        userManager.SetEmailAsync(userModel, userViewModel.Email);
        // Get all roles from user.
        var currentUserRoles = await userManager.GetRolesAsync(userModel);
        // Remove all current roles fro this user. You can skip it if you don't need it.
        var removeCurrentRolesResult = await userManager.RemoveFromRolesAsync(appUser, currentUserRoles);
        // Verify if any error occours
        if(!removeCurrentRolesResult.Succeeded)
        {
            // Add errors to ModelState.
            removeCurrentRolesResult.Errors.ToList().ForEach(t => ModelState.AddModelError("Role", t.Description));
            return View(userViewModel);
        }
        // get userRoles from text to an array of string;
        var newRoles = userViewModel.Roles.Split(',').Select(_ => _.Trim());
        // Adds user to the new role
        var addRoleResult = await _userManager.AddToRolesAsync(userModel, newRoles);
        if (!addRoleResult.Succeeded)
        {
          // handle errors like removeCurrentRolesResult
          return View(userViewModel);
        }
        // Return redirect to action object without need to remove async from method.
        return await Task.Run<ActionResult>(() => RedirectToAction("UserNotFound", userModel));
    }
    
