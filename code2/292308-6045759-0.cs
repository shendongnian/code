    void Main()
    {
    	DirectoryInfo info = new DirectoryInfo(@"C:\Personal");
    	ListContents(info);
    }
    
    public void ListContents(DirectoryInfo info)
    {
    	foreach(var dir in info.GetDirectories())
    	{
    		ListContents(dir);
    	}
    	foreach(var file in info.GetFiles())
    	{
    		Console.WriteLine(file.FullName);
    	}
    }
