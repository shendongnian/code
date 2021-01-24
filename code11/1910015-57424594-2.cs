    string source = "Hello World.";
    string input = "Goodbye World.";
    
    var sourceList = source.Split(' ').ToList(); 
    var inputList = input.Split(' ').ToList();
    
    for (int x = 0; x < inputList.Count; x++)
    {
    	if(sourceList[x] != inputList[x])
    	{
    		Console.WriteLine($"{x}\t{sourceList[x].ToString()}\t{inputList[x].ToString()}");
    	}
    }
