    // System.Runtime.Remoting.Messaging.CallContext
    /// <summary>Gets or sets the host context associated with the current thread.</summary>
    /// <returns>The host context associated with the current thread.</returns>
    /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
    public static object HostContext
    {
    	[SecurityCritical]
    	get
    	{
    		IllogicalCallContext illogicalCallContext = Thread.CurrentThread.GetIllogicalCallContext();
    		object hostContext = illogicalCallContext.HostContext;
    		if (hostContext == null)
    		{
    			LogicalCallContext logicalCallContext = CallContext.GetLogicalCallContext();
    			hostContext = logicalCallContext.HostContext;
    		}
    		return hostContext;
    	}
    	[SecurityCritical]
    	set
    	{
    		if (value is ILogicalThreadAffinative)
    		{
    			IllogicalCallContext illogicalCallContext = Thread.CurrentThread.GetIllogicalCallContext();
    			illogicalCallContext.HostContext = null;
    			LogicalCallContext logicalCallContext = CallContext.GetLogicalCallContext();
    			logicalCallContext.HostContext = value;
    			return;
    		}
    		LogicalCallContext logicalCallContext2 = CallContext.GetLogicalCallContext();
    		logicalCallContext2.HostContext = null;
    		IllogicalCallContext illogicalCallContext2 = Thread.CurrentThread.GetIllogicalCallContext();
    		illogicalCallContext2.HostContext = value;
    	}
    }
