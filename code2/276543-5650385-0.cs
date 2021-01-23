        string directory = "/";
    	foreach (string file in Directory.GetFiles(directory,"*.dll"))
    	{
    		Assembly assembly = Assembly.LoadFile(file);
    		foreach (Type ti in assembly.GetTypes().Where(x=>x.IsInterface))
    		{
    			if(ti.GetCustomAttributes(true).OfType<ServiceContractAttribute>().Any())
    			{
    				// ....
    			}
    		} 
    	}
