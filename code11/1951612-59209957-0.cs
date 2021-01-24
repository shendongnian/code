    public IViewComponentResult Invoke()
    {
    	ApplicationUser user = null;
    	if (_signInManager.IsSignedIn((ClaimsPrincipal)User))
    	{
    		var userId = _userManager.GetUserId((ClaimsPrincipal)User);
    		user = _userManager.FindByIdAsync(userId).Result;
    	}
    	return new CurrentUserVM()
    	{
    		ApplicationUser = user;
    	}
    }
