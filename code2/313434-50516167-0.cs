    using System;
    
    //Adapted from https://stackoverflow.com/a/6553276/1889720
    public static class ObjectExtensions
    {
    	public static bool IsNullOrDefault<TObject>(this TObject argument)
    	{
    		// deal with normal scenarios
    		if (argument == null)
    		{
    			return true;
    		}
    		if (object.Equals(argument, default(TObject)))
    		{
    			return true;
    		}
    
    		// deal with non-null nullables
    		Type methodType = typeof(TObject);
    		if (Nullable.GetUnderlyingType(methodType) != null)
    		{
    			return false;
    		}
    
    		// deal with boxed value types
    		Type argumentType = argument.GetType();
    		if (argumentType.IsValueType && argumentType != methodType)
    		{
    			object obj = Activator.CreateInstance(argument.GetType());
    			return obj.Equals(argument);
    		}
    
    		return false;
    	}
    }
