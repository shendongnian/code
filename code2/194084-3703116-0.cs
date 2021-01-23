    	// assuming the assembly has only ONE class
		// implementing the interface and method is void 
		private static void CallDoSomething(string assemblyPath, Type interfaceType, 
			string methodName, object[] parameters)
		{
			Assembly assembly = Assembly.LoadFrom(assemblyPath);
			Type t = assembly.GetTypes().Where(x=>x.GetInterfaces().Count(y=>y==interfaceType)>0).FirstOrDefault();
			if (t == null)
			{
				throw new ApplicationException("No type implements this interface");
			}
			MethodInfo mi = t.GetMethods().Where(x => x.Name == methodName).FirstOrDefault();
			if (mi == null)
			{
				throw new ApplicationException("No such method");
			}
			mi.Invoke(Activator.CreateInstance(t), parameters);
		}
