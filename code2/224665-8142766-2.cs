    private static void writeBinaryFile(string fileName, byte[] binaryArray)
    {
    	const int adTypeBinary = 1;
    	const int adSaveCreateOverWrite = 2;
    	using (dynamic adoCom = System.Runtime.InteropServices.Automation.AutomationFactory.CreateObject(@"ADODB.Stream"))
    	{
    		adoCom.Type = adTypeBinary;
    		adoCom.Open();
    		adoCom.Write(binaryArray);
    		adoCom.SaveToFile(fileName, adSaveCreateOverWrite);
    	}
    }
