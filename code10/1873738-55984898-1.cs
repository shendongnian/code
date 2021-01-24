    private async Task SignInUser(AppUser appUser)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, appUser.Email),
                    new Claim(ClaimTypes.Name, appUser.Displayname ?? appUser.Email),
                    new Claim(ClaimTypes.Email, appUser.Email),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties());
            }
