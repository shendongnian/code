    public T FindDescendantByName<T>(DependencyObject obj, string objname) where T : DependencyObject
    {
    	string controlneve = "";
    
    	Type tyype = obj.GetType();
    	if (tyype.GetProperty("Name") != null) {
    		PropertyInfo prop = tyype.GetProperty("Name");
    		controlneve = prop.GetValue((object)obj, null);
    	} else {
    		return null;
    	}
    
    	if (obj is T && objname.ToString().ToLower() == controlneve.ToString().ToLower()) {
    		return obj as T;
    	}
    
    	// Check for children
    	int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
    	if (childrenCount < 1)
    		return null;
    
    	// First check all the children
    	for (int i = 0; i <= childrenCount - 1; i++) {
    		DependencyObject child = VisualTreeHelper.GetChild(obj, i);
    		if (child is T && objname.ToString().ToLower() == controlneve.ToString().ToLower()) {
    			return child as T;
    		}
    	}
    
    	// Then check the childrens children
    	for (int i = 0; i <= childrenCount - 1; i++) {
    		string checkobjname = objname;
    		DependencyObject child = FindDescendantByName<T>(VisualTreeHelper.GetChild(obj, i), objname);
    		if (child != null && child is T && objname.ToString().ToLower() == checkobjname.ToString().ToLower()) {
    			return child as T;
    		}
    	}
    
    	return null;
    }
