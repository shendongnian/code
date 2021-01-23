	static string FindAppPath(string appName)
	{
		// If you don't use contracts, check this and throw ArgumentException
		Contract.Requires(!string.IsNullOrEmpty(appName));
		const string keyPath =
			@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
		using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
		{
			var installed = 
				(from skName in key.GetSubKeyNames()
				let subkey = key.OpenSubKey(skName)
				select new
				{
					name = subkey.GetValue("DisplayName") as string,
					path = subkey.GetValue("InstallLocation") as string
				}).ToList();
			var desired = installed.FindAll(
				program => program.name != null && 
				program.name.Contains(appName)  &&
				!String.IsNullOrEmpty(program.path));
			return (desired.Count > 0) ? desired[0].path : null;
		}
	}
