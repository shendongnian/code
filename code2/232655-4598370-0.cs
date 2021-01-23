    private string GetExecutingMethodName()
    		{
    			string result = "Unknown";
    			StackTrace trace = new StackTrace(false);
    			Type type = GetType();
    
    			for (int index = 0; index < trace.FrameCount; ++index)
    			{
    				StackFrame frame = trace.GetFrame(index);
    				MethodBase method = frame.GetMethod();
    
    				if (method.DeclaringType != type && !type.IsAssignableFrom(method.DeclaringType))
    				{
    					result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
    					break;
    				}
    			}
    
    			return result;
    		}
