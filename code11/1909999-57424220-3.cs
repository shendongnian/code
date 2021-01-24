    public async Task<IActionResult> OnPostAsync(IFormFile file = null)
    {
    	if (!ModelState.IsValid)
    	{
    		return Page();
    	}
    	if(Input.ProfilePicToUpdate != null && Input.ProfilePicToUpdate.Length > 0)
    	{
    		using (var memoryStream = new MemoryStream())
    		{
    			await Input.ProfilePicToUpdate.CopyToAsync(memoryStream);
    			var profilePicBytes = memoryStream.ToArray();
    
    			if(user.ProfilePic == null || !profilePicBytes.SequenceEqual(user.ProfilePic))
    			{
    				user.ProfilePic = memoryStream.ToArray();
    				var setProfilePic = await _userManager.UpdateAsync(user);
    				if (!setProfilePic.Succeeded)
    				{
    					throw new ApplicationException($"Unexpected error occurred setting profile picture for user with ID '{user.Id}'.");
    				}
    			}
    		}
    	}
    	
    }
