     services.AddAuthentication(options => { options.DefaultScheme = 
        CookieAuthenticationDefaults.AuthenticationScheme; })
       .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
         //options.LoginPath = new PathString(Constants.SignIn);
         //options.LogoutPath = new PathString(Constants.SignOut);
         options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
        });
