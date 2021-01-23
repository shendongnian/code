    private static void PinUnpinTaskBar(string filePath, bool pin)
    {
    	if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
    
    	// create the shell application object
    	var shellType = Type.GetTypeFromProgID("Shell.Application");
    
    	var shellApplication = Activator.CreateInstance(shellType);
    
    	string path = Path.GetDirectoryName(filePath);
    	string fileName = Path.GetFileName(filePath);
    
    	var directory = shellType.InvokeMember("Namespace", BindingFlags.InvokeMethod, null, shellApplication, new object[] { path });
    	var link = directory.GetType().InvokeMember("ParseName", BindingFlags.InvokeMethod, null, directory, new object[] {fileName});
    	var verbs = link.GetType().InvokeMember("Verbs", BindingFlags.InvokeMethod, null, link, new object[] { });
    
    	int verbsCount = (int)verbs.GetType().InvokeMember("Count", BindingFlags.InvokeMethod, null, verbs, new object[] { });
    
    	for (int i = 0; i < verbsCount; i++)
    	{
    		var verb = verbs.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, verbs, new object[] { i });
    
    		var namePropertyValue = (string)verb.GetType().GetProperty("Name").GetValue(verb, null);
            var verbName = namePropertyValue.Replace(@"&", string.Empty).ToLower();
    		
    		if ((pin && verbName.Equals("pin to taskbar")) || (!pin && verbName.Equals("unpin from taskbar")))
    		{
    
    			verbs.GetType().InvokeMember("DoIt", BindingFlags.InvokeMethod, null, verbs, new object[] { });
    		}
    	}
    
    	shellApplication = null;
    }
