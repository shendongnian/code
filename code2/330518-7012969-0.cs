    public static object FindNamedObject(FrameworkElement container, string name)
    {
    	var target = container.FindName(name);
    	if (target == null)
    	{
    		int count = VisualTreeHelper.GetChildrenCount(container);
    		for (int i = 0; i < count; i++)
    		{
    			var child = VisualTreeHelper.GetChild(container, i) as FrameworkElement;
    			if (child != null)
    			{
    				target = FindNamedObject(child, name);
    				if (target != null)
    				{
    					break;
    				}
    			}
    		}
    	}
    	return target;
    }
