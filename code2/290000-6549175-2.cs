    public sealed class Security
    {
    	public static IPermission CreatePermission()
    	{
    		var stackTrace = new StackTrace();
    
    		var fullnameArray = new List<String>();
    		foreach (var frame in stackTrace.GetFrames())
    		{
    			try
    			{
    				var method = frame.GetMethod();
    				if (method != null && method.ReflectedType.IsSubclassOf(typeof(BaseClass)))
    					fullnameArray.Add(method.ReflectedType.FullName);
    			}
    			catch { }
    		}
    		if (fullnameArray.Count() > 0)
    		{
    			return new PrincipalPermission(null, fullnameArray[0]);
    		}
    		return new PrincipalPermission(PermissionState.Unrestricted);
    	}
    }
    
    public class MyClassCalledFirstWork : BaseClass
    {
    	public override void DoSomething()
    	{
    		Security.CreatePermission().Demand();
    		return;
    	}
    }
    
    public class MyClassCalledSecondDontWork : BaseClass
    {
    	public override void DoSomething()
    	{
    		Security.CreatePermission().Demand();
    		return;
    	}
    }
