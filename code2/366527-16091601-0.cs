    class SessionFixationIdManager : ISessionIDManager
    {
    	private SessionIDManager _originalManager = new SessionIDManager();
    
    	public string CreateSessionID(System.Web.HttpContext context)
    	{
    		// Default process for creating session IDs is fine...
    		return _originalManager.CreateSessionID(context);
    	}
    
    	etc.
    }
