    public void CollectTypes(Type type, HashSet<Type> types)
    {
    	if (types.Contains(type)) return;
    	types.Add(type);
    	
    	foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
    	{
    		if (!fi.IsInitOnly)
    		{
    			CollectTypes(fi.FieldType, types);
    		}
    	}
    
    	foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
    	{
    		if (pi.CanWrite && pi.CanRead)
    		{
    			CollectTypes(pi.PropertyType, types);
    		}
    	}
    }
