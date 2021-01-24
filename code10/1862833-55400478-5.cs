    private bool HandlemyRegistry()
    {
    	const string RegKey = @"SOFTWARE\mySettings";
    	const string ValueKey = "FirstRun";
    	
    	var date = DateTime.Now.Date;
    
    	var key = Registry.LocalMachine.OpenSubKey(RegKey);
    	if (key is null)
    	{
    		key = Registry.LocalMachine.CreateSubKey(RegKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
    		key.SetValue(ValueKey, date.Ticks, RegistryValueKind.QWord);
    	}
    	else
    	{
    		date = new DateTime((long)key.GetValue(ValueKey, date.Ticks));
    	}
    	key.Close();
    	
    	return (DateTime.Now - date).Days <= 20;
    }
