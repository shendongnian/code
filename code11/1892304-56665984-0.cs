            public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                var user = new ApplicationUser
                {
                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                    UserData = new UserData { Email = info.Principal.FindFirstValue(ClaimTypes.Email) }
                };
                var registrationResult = await userManager.CreateAsync(user);
                if (registrationResult.Succeeded)
                {
                    registrationResult = await userManager.AddLoginAsync(user, info);
                    if (registrationResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                        throw new Exception("trut Błąd! External provider assocation error");
                }
                else
                    throw new Exception("trut błąd! Registration error");
            }
            
        }
