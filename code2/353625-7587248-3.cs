	var yourClassInstance = new YourClass();
	string input
	bool inputRead = false;
	
	while(!inputRead) 
	{
		var input = Console.ReadLine();
		
		inputRead = YourClass.IsNameValid(input);
	}
	yourClassInstance.Name = inputRead;
	
