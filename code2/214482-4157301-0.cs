    public List<int> FilterNumbers(string fileName)
    {
    	StreamReader sr = File.OpenTest(fileName);
    	string s = "";
    	Dictionary<int, bool> numbers = new Dictionary<int, bool>();
    	while((s = sr.ReadLine()) != null)
    	{
    		int number = Int32.Parse(s);
    		numbers.Add(number,true);
    	}
    	foreach(int number in numbers.Keys)
    	{
    		if(numbers[number])
    		{
    			if(numbers.ContainsKey(100000+number))
    				numbers[100000+number]=false;
    			if(numbers.ContainsKey(10000+number))
    				numbers[10000+number]=false;
    			if(numbers.ContainsKey(1000+number))
    				numbers[1000+number]=false;
    			if(numbers.ContainsKey(100+number))
    				numbers[100+number]=false;
    			if(numbers.ContainsKey(10+number))
    				numbers[10+number]=false;
    			if(numbers.ContainsKey(1+number))
    				numbers[1+number]=false;
    		}
    	}
    	
    	List<int> validNumbers = new List<int>();
    	foreach(int number in numbers.Keys)
    	{
    		validNumbers.Add(number);
    	}
    	return validNumbers;
    }
