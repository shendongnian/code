    3 type login with OAuth2.
     private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user,  DefaultAuthenticationTypes.ApplicationCookie);
    AuthenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = isPersistent }, identity);
        }
      [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.UserName, model.Password);
                //Update : here we need to optimize code , because we have many roles and logins.
                //According to role we need to open Dashboards.
                if (user != null)
                {
                    IList<string> roles = await _userManager.GetRolesAsync(user.Id);
                    if (roles.Count != 0)
                    {
                        this.SessionState.ThemeName = user.ThemeName;
                        this.SessionState.UserId = user.Id;
                        this.SessionState.CustomerId = user.CustomerId.ToString();
                        this.SessionState.UserRole = roles.FirstOrDefault().ToString();
     if (SessionState.UserRole == UserRoleNames.ClinicAdmin || SessionState.UserRole == UserRoleNames.ClinicStaff || SessionState.UserRole == UserRoleNames.Patient)
                        {
                            this.SessionState.SiteId = user.SiteId.ToString();
                        }
                        else
                        {
                            this.SessionState.SiteId = null;
                        }
                        
                        await SignInAsync(user, model.RememberMe);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your account is not activate ,Please contact administrator");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or    password.");
                }
            }
            return this.AjaxableView(model);
        }
     [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return this.AjaxableView("ExternalLoginFailure");
                }
                var user = new User() { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }
            ViewBag.ReturnUrl = returnUrl;
            return this.AjaxableView(model);
        }
      // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }
            var user = await _userManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return this.AjaxableView("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }
