     services.AddAuthentication(options => { 
            options.DefaultScheme = "Cookies"; 
        }).AddCookie("Cookies", options => {
            options.Cookie.Name = "auth_cookie";
            options.Cookie.SameSite = SameSiteMode.None;
            options.Events = new CookieAuthenticationEvents
            {                          
                OnRedirectToLogin = redirectContext =>
                {
                    redirectContext.HttpContext.Response.StatusCode = 401;
                    return Task.CompletedTask;
                }
            };                
        });
    
