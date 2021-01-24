	string methodName = ControllerContext.RouteData.Values["action"].ToString();
	Assembly asm = Assembly.GetExecutingAssembly();
	var methodInfo = asm.GetTypes()
	    .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
	    .SelectMany(type => type.GetMethods())
	    .Where(method => method.IsPublic)
	    .Where(x => x.DeclaringType != null)
	    .Where(x => x.Name == methodName)
	    .SingleOrDefault();
	if (methodInfo == null)
	{
	    return null; // Method wasn't found
	}
	if (typeof(JsonResult) == methodInfo.ReturnType)
	{
	    // Return JSON
	}
	else if (typeof(JsonResult) == methodInfo.ReturnType)
	{
	    // Redirect
	}
	else
	{
	    // Exception handling
	}
