    var type = pinfo.GetGetMethod().Invoke(obj, new object[0]).GetType();
    if (type.IsArray)
    {
    	Array a = (Array)obj;
    	foreach (object arrayVal in a)
    	{
    		// reflect on arrayVal now
    		var elementType = arrayVal.GetType();
    	}
    }
