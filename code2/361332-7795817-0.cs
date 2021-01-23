    using(var sw = new StreamWriter(path3))
    using(var sr = new StreamReader(path2))
    {
    	string[] lines = File.ReadAllLines(path);
    	
    	foreach (string line in lines)
    	{
    		string user = sr.ReadLine();
    		
    		if (line != user)
    		{
    			sw.WriteLine(line);
    		}
    	}
    }
