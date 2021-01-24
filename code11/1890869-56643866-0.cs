                var result = (from U in db.Users
                              from R in U.Roles
                              join R2 in db.Roles on R.RoleId equals R2.Id
                              where U.Id == loggedInUserId
                              select new { R2.Name, U.UserName }).FirstOrDefault();
    
                ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
                identity.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", result.Name));
    
                IOwinContext context = new OwinContext();
    
                context.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                context.Authentication.SignIn(identity);
    
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    
                if (User.IsInRole("Administrator"))
                {
                    isAdmin = true;
                }
