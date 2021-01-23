    var registryViewArray = new[] { RegistryView.Registry32, RegistryView.Registry64 };
    
    foreach (var registryView in registryViewArray)
    {
    	using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
    	using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
    	{
    		var instances = (string[]) key?.GetValue("InstalledInstances");
    		if (instances != null)
    		{
    			foreach (var element in instances)
    			{
    				if (element == "MSSQLSERVER")
    					Console.WriteLine(System.Environment.MachineName);
    				else
    					Console.WriteLine(System.Environment.MachineName + @"\" + element);
    
    			}
    		}
    	}
    }
    
    Console.ReadKey();
