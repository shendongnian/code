    internal static T FindVisualChild<T>(this DependencyObject parent) where T : DependencyObject
    {
    	if (parent == null)
    	{
    		return null;
    	}
    
    	DependencyObject parentObject = parent;
    	int childCount = VisualTreeHelper.GetChildrenCount(parent);
    	for (int i = 0; i < childCount; i++)
    	{
    		DependencyObject childObject = VisualTreeHelper.GetChild(parentObject, i);
    		if (childObject == null)
    		{
    			continue;
    		}
    
    		var child = childObject as T;
    		return child ?? FindVisualChild<T>(childObject);
    	}
    
    	return null;
    }
