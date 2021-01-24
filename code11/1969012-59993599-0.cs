    public class MenuItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Roles { get; set; }
    	
    	public static MenuItem For(Delegate method)
    	{
    		var methodInfo = method.GetMethodInfo();
    		var attributes = methodInfo
                .GetCustomAttributes(typeof(AuthorizeAttribute))
                .Cast<AuthorizeAttribute>();
    		
            // If no attribute is defined on the action method, check the controller itself
    		if (attributes.Count() == 0)
    		{
    			attributes = methodInfo.DeclaringType
                    .GetCustomAttributes(typeof(AuthorizeAttribute))
                    .Cast<AuthorizeAttribute>();
    		}
    		
    		return new MenuItem
    		{
    			Action = methodInfo.Name,
    			Controller = methodInfo.DeclaringType.Name,
    			Roles = string.Join(',', attributes.Select(a => a.Roles))
    		};
    	}
    }
