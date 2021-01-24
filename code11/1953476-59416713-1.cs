    private string GetDefaultBrowserOnWin10()
    {
    	string execPath;
    	try
    	{
    		string extension = ".htm"; // either .htm or .html
    		RegistryKey propertyBag = Registry.CurrentUser.OpenSubKey($@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\{extension}\UserChoice", false);
    		var browserProgId = propertyBag.GetValue("ProgId").ToString(); ;
    		using (RegistryKey execCommandKey = Registry.ClassesRoot.OpenSubKey(browserProgId + @"\shell\open\command", false))
    		{
    			execPath = execCommandKey.GetValue(null).ToString().ToLower().Replace("\"", "");
    			if (IsDefaultLauncherApp(execPath))
    			{
    				System.Diagnostics.Debug.WriteLine("No user-defined browser or IE selected; anchor will be lost.");
    			}
    		}
    
    		if (!execPath.EndsWith("exe"))
    		{
    			execPath = execPath.Substring(0, execPath.LastIndexOf(".exe") + 4);
    		}
    	}
    	catch (Exception ex)
    	{
    		System.Diagnostics.Debug.WriteLine(ex.Message);
    		execPath = GetDefaultBrowser();
    	}
    
    	return execPath;
    }
    
    private bool IsDefaultLauncherApp(string appPath)
    {
    	return appPath.Contains("launchwinapp.exe");
    }
