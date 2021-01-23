	using System;
	using System.Reflection;
	
	private void PreloadDLLs()
	{
		Assembly assembly = Assembly.GetEntryAssembly();
		System.Reflection.AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
		foreach(System.Reflection.AssemblyName referencedAssemblyName in referencedAssemblies)
		{
			try
			{
				Assembly a = assembly.Load(referencedAssemblyName);
			}
			catch
			{
			}
		}
	}
