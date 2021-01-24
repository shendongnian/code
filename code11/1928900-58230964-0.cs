        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
		if (result.Succeeded)
		{
			return RedirectToAction("Index", "Home");
		}
		if (result.IsLockedOut)
		{
			return RedirectToAction(nameof(Lockout));
		}
		else
		{
		    var user = await _userManager.FindByEmailAsync(email);
		    if (user != null)
		    {
			    var resultTemp = await _userManager.AddLoginAsync(user, info);
			    if (resultTemp.Succeeded)
			    {
				    await _signInManager.SignInAsync(user, isPersistent: true);
				    return RedirectToAction("Index", "Home");
			    }
		    }
		    // User does not have an account, then ask the user to create an account.
			ViewData["ReturnUrl"] = returnUrl;
			ViewData["LoginProvider"] = info.LoginProvider;
			var email = info.Principal.FindFirstValue(ClaimTypes.Email);
			return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
		}
