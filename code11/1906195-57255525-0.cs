    services.AddIdentity<User, IdentityRole>(options =>
    {
    	options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
    	{
    		OnRedirectToLogin = ctx =>
    		{
    		   if (ctx.Request.Path.StartsWithSegments("/api") &&
    			   ctx.Response.StatusCode == (int) HttpStatusCode.OK)
    		   {
    			   ctx.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
    		   }
    		   else
    		   {
    			   ctx.Response.Redirect(ctx.RedirectUri);
    		   }
    		   return Task.FromResult(0);
    		}
    	};
    });
