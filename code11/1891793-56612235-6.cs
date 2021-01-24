    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            //here send back the error and the model with validation message to any view
            TempData["LoginModel"] = model;
            TempData["LoginError"] = "Incorrect details";
            return Redirect(returnUrl);
        }
        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        switch (result)
        {
            case SignInStatus.Success:
                return RedirectToLocal(returnUrl);
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
                TempData["LoginModel"] = model;
                TempData["LoginError"] = "Invalid login attempt";
                return Redirect(returnUrl);                    
        }
    }
