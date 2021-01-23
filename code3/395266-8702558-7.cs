    // System.Web.Hosting.ContextBase
    internal static object Current
    {
    	get
    	{
    		return CallContext.HostContext;
    	}
    	[SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    	set
    	{
    		CallContext.HostContext = value;
    	}
    }
