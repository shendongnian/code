    public void AddprogramToStartUp()
    {
    	try
    	{
    		Log.Info("Checking if app is added to windows startup");
    
    		string appName = "TestApplication";
    		RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
    		var val = Convert.ToString(rk.GetValue(appName));
    		if (string.IsNullOrEmpty(val))
    		{
    			rk.SetValue(appName, Application.ExecutablePath);
    			Log.Info("Added!");
    		}
    		else
    			Log.Info("Already added!");
    	}
    	catch(Exception e)
    	{
    		Log.Error("Failed to add/check windows startup", e);
    	}
    }
