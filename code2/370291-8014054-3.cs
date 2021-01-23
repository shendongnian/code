	public static class ConfigurationTaskRunner
	{
		public static void Execute( params string[] assemblyNames )
		{
			var assemblies = assemblyNames.Select( Assembly.Load ).Distinct().ToList();
			Execute( assemblies );
		}
		public static void Execute( IEnumerable<Assembly> assemblies )
		{
			var tasks = new List<IConfigurationTask>();
			assemblies.ForEach( a => tasks.AddRange( a.CreateInstances<IConfigurationTask>() ) );
			tasks.ForEach( t => t.Configure() );
		}
	}
