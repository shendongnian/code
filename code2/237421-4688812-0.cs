		public string GetOsVersion(string ipAddress)
		{
			using (var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, ipAddress))
			using (var key = reg.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\"))
			{
				return string.Format("Name:{0}, Version:{1}", key.GetValue("ProductName"), key.GetValue("CurrentVersion"));
			}
		}
