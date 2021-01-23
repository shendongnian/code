    public static T CopyEntity<T>(MyContext ctx, T entity, bool copyKeys = false) where T : EntityObject
    {
	    T clone = ctx.CreateObject<T>();
	    PropertyInfo[] pis = entity.GetType().GetProperties();
	
	    foreach (PropertyInfo pi in pis)
	    {
		    EdmScalarPropertyAttribute[] attrs = (EdmScalarPropertyAttribute[])pi.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false);
			
		    foreach (EdmScalarPropertyAttribute attr in attrs)
		    {
			    if (!copyKeys && attr.EntityKeyProperty)
				    continue;
				
			    pi.SetValue(clone, pi.GetValue(entity, null), null);
		    }
	    }
	
	    return clone;
    }
