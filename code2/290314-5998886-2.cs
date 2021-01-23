    class Sandbox : MarshalByRefObject
	{
		const string BaseDirectory = "Untrusted";
		const string DomainName = "Sandbox";
		public Sandbox()
		{
		}
		public static Sandbox Create()
		{
			var setup = new AppDomainSetup()
			{
				ApplicationBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BaseDirectory),
				ApplicationName = DomainName,
				DisallowBindingRedirects = true,
				DisallowCodeDownload = true,
				DisallowPublisherPolicy = true
			};
			var permissions = new PermissionSet(PermissionState.None);
			permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
			permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
			var domain = AppDomain.CreateDomain(DomainName, null, setup, permissions,
				typeof(Sandbox).Assembly.Evidence.GetHostEvidence<StrongName>());
			return (Sandbox)Activator.CreateInstanceFrom(domain, typeof(Sandbox).Assembly.ManifestModule.FullyQualifiedName, typeof(Sandbox).FullName).Unwrap();
		}
	    public string Execute(string assemblyPath, string scriptType, string method, params object[] parameters)
        {
            new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, assemblyPath).Assert();
			var assembly = Assembly.LoadFile(assemblyPath);
			CodeAccessPermission.RevertAssert();
			Type type = assembly.GetType(scriptType);
			if (type == null)
				return null;
			var instance = Activator.CreateInstance(type);
			return Format(type.GetMethod(method).Invoke(instance, parameters);
        }
    }
