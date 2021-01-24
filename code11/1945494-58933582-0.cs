    string[] valueList = new string[] { "inject", "cheatengine", "cheatengine", "cheat" };
    static void Hello(string[] args)
    {
    	string mystring = "Test data";
    	if (IsMatch(mystring))
    	{
    		FindHack();
    	}
    }
    
    public bool IsMatch(string data)
    {
    	foreach (var item in valueList)
    	{
    		if (data.ToLower().Contains(item))
    		{
    			return true;
    		}
    	}
    	return false;
    }
    
    private void FindHack()
    {
    	Console.WriteLine("HILE BULUNDU.");
    	Process[] Fivem = Process.GetProcessesByName("Fivem");
    	foreach (Process hope in Fivem)
    		hope.Kill();
    	clsProcess.Kill();
    }
