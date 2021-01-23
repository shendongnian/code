    public static void RunMethod(string script, string method, object[] param)
    {
    	try
    	{
    		dynamic dynamicObj = Scripts[script];
    		var operations = ironPython.Operations;
    		operations.InvokeMember(dynamicObj, method, param);
    	}
    	catch { }
    }
