    public static IEnumerable<Control> GetControlHierarchy(Control parent, string controlID)
    {
    	foreach (var ctrl in parent.Controls)
    	{
    		if(ctrl.Id == controlID)
    			yield return ctrl;
    		else
    		{
    			var result = GetControlHierarchy(ctrl, controlID);
    			if(result != null)
    				return result.Concat(ctrl);
    		}
    		return null;
    	}
    }
