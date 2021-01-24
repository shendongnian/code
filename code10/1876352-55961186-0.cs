    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);
        var userDTO = new ExpandedUserDTO();
        switch (result)
        {                            
            case SignInStatus.Success:
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                return RedirectToAction("RedirectLogin");
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
            case SignInStatus.Failure:
            default:
                ModelState.AddModelError("", "Falha ao Realizar login, usuário ou senha incorretos.");
                return View(model);
        }
    }
