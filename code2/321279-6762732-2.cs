    try
    {
    	using(var sw = new StreamWriter(File.Open("text.txt", FileMode.OpenOrCreate)))
    	{
    		sw.Write("some text");
    	}
    }
    catch
    {
    	// handle exception
    }
    
    
    try
    {
    	using(var sw = new StreamWriter(File.Open("otherfile.txt", FileMode.OpenOrCreate)))
    	{
    		sw.Write("some other text");
    	}
    }
    catch
    {
    	// handle exception
    }
