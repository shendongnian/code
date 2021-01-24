    public class MenuItem
    {
        public string Action { get; private set; }
        public string Controller { get; private set; }
        public string Roles { get; private set; }
        private MenuItem() { }
    	
    	public static MenuItem For<TMethod>(TMethod method) where TMethod : Delegate
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
