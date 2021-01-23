    private HttpControllerDescriptor TryGetControllerWithMatchingMethod(string version, string controllerName, string actionName)
    {
    	var versionNumber = Convert.ToInt32(version.Substring(1, version.Length - 1));
    	while(versionNumber >= 1) { 
    		var controllerFullName = string.Format("Namespace.Controller.V{0}.{1}Controller, Namespace.Controller.V{0}", versionNumber, controllerName);
    		Type type = Type.GetType(controllerFullName, false, true);
    
    		var matchFound = type != null && type.GetMethod(actionName) != null;
    
    		if (matchFound)
    		{
    			var key = string.Format(CultureInfo.InvariantCulture, "V{0}{1}", versionNumber, controllerName);
    			HttpControllerDescriptor controllerDescriptor;
    			if (_controllers.TryGetValue(key, out controllerDescriptor))
    			{
    				return controllerDescriptor;
    			}
    		}
    		versionNumber--;
    	}
    
    	return null;
    }
