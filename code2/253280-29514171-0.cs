		private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return
				AppDomain.CurrentDomain.GetAssemblies()
				.FirstOrDefault(Kandidaat => string.Equals(Kandidaat.GetName().FullName, args.Name));
		}
