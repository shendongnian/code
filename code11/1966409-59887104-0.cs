    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                foreach (var role in _userManager.GetRolesAsync(user).Result)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationProperties _authentication = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow
                };
                await _HttpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
