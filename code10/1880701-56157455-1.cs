	services.AddAuthorization(options =>
	{
		options.AddPolicy("ValidateCertificate", policy =>
		   policy.RequireAssertion(context => 
		   {
			   var filterContext = (AuthorizationFilterContext)context.Resource;
			   var Response = filterContext.HttpContext.Response;
			   var message = Encoding.UTF8.GetBytes("Invalid certificate");
			   Response.OnStarting(async () =>
			   {
				   filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				   await Response.Body.WriteAsync(message, 0, message.Length);
			   });                       
			   return false;
		   }));
	});
