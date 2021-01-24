    var user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);
    
    var isInRole = await _signInManager.UserManager.IsInRoleAsync(user, "Admin");
    if (isInRole)
    {
        return LocalRedirect("YourURL");
    }
