    private static IList<AccessorDescriptor> GetPropertyAccessors<TTarget>()
	{
		return GetPropertyAccessors(typeof(TTarget));
	}
	
    private static IList<AccessorDescriptor> GetPropertyAccessors(Type targetType)
    {
		// I believe this should ensure that we catch all defined properties
        var allProps = targetType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.GetProperty | BindingFlags.SetProperty);
        
		// Create a list which will support all of the properties getters and setters
		var result = new List<AccessorDescriptor>(allProps.Count() * 2);
		
        foreach (var prop in allProps)
        {
			// Get the properties accessors
            foreach (var accessor in prop.GetAccessors(true))
            {
				// Determine if it's a getter or a setter
                if (accessor.ReturnType == typeof(void))
                {
                    result.Add(new AccessorDescriptor(accessor, prop, isGetter: false, isSetter: true));
                }
                else
                {
                    result.Add(new AccessorDescriptor(accessor, prop, isGetter: true, isSetter: false));
                }
            }
        }
		// Return the list
        return result;
    }
	
