    private static byte[] readBinaryFile(string fileName)
    {
    	const int adTypeBinary = 1;
    
    	using (dynamic adoCom = System.Runtime.InteropServices.Automation.AutomationFactory.CreateObject(@"ADODB.Stream"))
    	{
    		adoCom.Type = adTypeBinary;
    		adoCom.Open();
    		adoCom.LoadFromFile(fileName);
    
    		return adoCom.Read();
    	}
    }
	
