    [HttpPost]
    public IActionResult Login([FromBody] LoginViewModel loginViewModel)
    {
        User user = authenticationService.ValidateUserCredentials(loginViewModel.Username, loginViewModel.Password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            return Redirect(loginViewModel.ReturnUrl);
        }
        ModelState.AddModelError("LoginError", "Invalid credentials");
        return View(loginViewModel);
    }
