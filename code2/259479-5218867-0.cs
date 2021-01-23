    string path = @"C:\temp\temp.txt";
    string allText = null;
    int attempt = 0;
    const int maxAttempts = 3;
    do
    {
    	try
    	{
    		allText = File.ReadAllText(path);
    		File.Delete(path);
    		break;
    	}
    	catch (IOException)
    	{
    		if (attempt < maxAttempts)
    		{
    			System.Threading.Thread.Sleep(1000);
    			attempt++;
    		}
    		else
    		{
    			throw;
    		}
    	}
    } while (attempt < maxAttempts);
    
    ProcessFileText(allText);
