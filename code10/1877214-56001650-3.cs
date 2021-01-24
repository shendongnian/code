    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
    var user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);
    // Get the roles for the user
    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                              
    if (roles.Any(role=>"Admin".Equals(role)))
    {
        return LocalRedirect("YourURL");
    }
