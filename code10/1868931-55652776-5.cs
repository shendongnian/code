    //Inside your SignIn method
        //User info should be taken from DB
        MyCustomUser user = new MyCustomUser()
        {
            Id = 1,
            Name = "Mr.Awesome",
            GivenName = "John Doe"
        };
     
        //Add user information
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.GivenName, user.GivenName)
        };
     
        //Create the principal user from the claims
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        AuthenticationProperties authenticationProperties = new AuthenticationProperties() {IsPersistent = false};
     
        //Create the authentication cookie and store it
        await this.HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                 principal, authenticationProperties);
     
       // DONE!
