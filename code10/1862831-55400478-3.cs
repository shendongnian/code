    private bool HandlemyRegistry()
    {
    	var date = DateTime.Now.Date;
    
    	var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\mySettings");
    	if (key is null)
    	{
    		key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\mySettings", RegistryKeyPermissionCheck.ReadWriteSubTree);
    		key.SetValue("FirstRun", date.Ticks, RegistryValueKind.QWord);
    	}
    	else
    	{
    		date = new DateTime((long)key.GetValue("FirstRun", date.Ticks));
    	}
    	key.Close();
    	
    	return (DateTime.Now - date).Days <= 20;
    }
