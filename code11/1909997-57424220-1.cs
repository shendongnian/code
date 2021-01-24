    public async Task<IActionResult> OnGetAsync()
    {
    	var user = await _userManager.GetUserAsync(User);
    	if (user == null)
    	{
    		throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
    	}
    
    	Input = new InputModel
    	{
    		ProfilePic = user.ProfilePic,
    		XP = user.XP,
    		Address = user.Address,
    		BirthDate = user.BirthDate
    	};
    	return Page();
    }
