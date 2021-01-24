    public static List<Settlement> ReadFromLogFile()
    {
    	string filename = path + @"\BM_DB_MIGRATION.txt";
    	List<Settlement> settlements = new List<Settlement>();
    
    	if (File.Exists(filename))
    	{
    		string[] lines = File.ReadAllLines(filename);
    
    		// Reading 7 elements from lines into an object of Settelment at each iteration 
    		// and store the object in a list of objects...
    		
    		for(int i = 0; i < lines.length; i += 7)
    		{
    			var obj = lines.Skip(i).Take(7).ToArray();
    			var settlement = new Settlement(obj);
    			
    			settlements.Add(settlement);
    		}
    	}
    
    	return settlements;
    }
