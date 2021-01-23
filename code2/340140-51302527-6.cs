	void RunAttributes ()
	{
		try
		{
			Type[] allTypes = Assembly.GetExecutingAssembly ().GetTypes ();
			foreach (Type t in allTypes)
			{
				Type baseType = t.BaseType;
				if (baseType != null && baseType != typeof (object))
				{
					var a = baseType.GetCustomAttribute<RestrictedInheritabilityAttribute> ();
					if (a != null) a.CheckForException (t);
				}
			}
		}
		catch (Exception e)
		{
			throw e;
		}
	}
