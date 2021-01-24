    [HttpPost]
    [Route("Login")]
    public IActionResult Login(LoginModel model)
    {
      var claims = new List<Claim> {
        // create claim
        ...
      };
      var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
      var userPrincipal = new ClaimsPrincipal(userIdentity);
      HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
      userPrincipal,
      new AuthenticationProperties
      {
        IssuedUtc = DateTime.UtcNow,
        IsPersistent = false,
        ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
      });
    }
