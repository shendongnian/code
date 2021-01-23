 	private static string GetExecutablePathForService(string serviceName, RegistryView registryView, bool throwErrorIfNonExisting)
		{
			string registryPath = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
			RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registryPath);
			if(key==null)
			{
				if (throwErrorIfNonExisting)
					throw new ArgumentException("Non-existent service: " + serviceName, "serviceName");
				else
					return null;
			}
			string value = key.GetValue("ImagePath").ToString();
			key.Close();
			if(value.StartsWith("\""))
			{
				value = Regex.Match(value, "\"([^\"]+)\"").Groups[1].Value;
			}
			return Environment.ExpandEnvironmentVariables(value);
		}
