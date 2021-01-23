    private static void Get45or451FromRegistry()
    {
    	using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\")) {
    		if (ndpKey != null && ndpKey.GetValue("Release") != null) {
    			Console.WriteLine("Version: " + CheckFor45DotVersion((int) ndpKey.GetValue("Release")));
    		}
          else {
             Console.WriteLine("Version 4.5 or later is not detected.");
          } 
    	}
    }
