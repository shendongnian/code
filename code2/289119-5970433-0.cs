    object CallMethodReflection(object o, string nameMethod, params object[] args)
    {
    	try
    	{
    		var types = TypesFromObjects(args);
    		var oType = o.GetType();
    		MethodInfo theMethod = null;
    
    		// If any types are null have to perform custom resolution logic
    		if (types.Any(type => type == null)) 
    		{
    			foreach (var method in oType.GetMethods().Where(method => method.Name == nameMethod))
    			{
    				var parameters = method.GetParameters();
    
    				if (parameters.Length != types.Length)
    					continue;
    
    				//check to see if all the parameters match close enough to use
    				bool methodMatches = true;
    				for (int paramIndex = 0; paramIndex < parameters.Length; paramIndex++)
    				{
    					//if arg is null, then match on any non value type
    					if (args[paramIndex] == null)
    					{
    						if (parameters[paramIndex].ParameterType.IsValueType)
    						{
    							methodMatches = false;
    							break;
    						}
    					}
    					else //otherwise match on exact type, !!! this wont handle things passing a type derived from the parameter type !!!
    					{
    						if (parameters[paramIndex].ParameterType != args[paramIndex].GetType())
    						{
    							methodMatches = false;
    							break;
    						}
    					}
    				}
    
    				if (methodMatches)
    				{
    					theMethod = method;
    					break;
    				}
    			}
    		}
    		else
    		{
    			theMethod = oType.GetMethod(nameMethod, types);
    		}
    		
    		Console.WriteLine("Calling {0}", theMethod);
    		return theMethod.Invoke(o, args);
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Could not call method: {0}, error: {1}", nameMethod, ex.ToString());
    		return null;
    	}
    }
