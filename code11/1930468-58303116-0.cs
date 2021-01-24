    int total = 0;
    int count = 0;
    
    Console.Write("Enter your number: ");
    
    while (true)
    {
    	int input = 0;
    
    	bool isNumber = int.TryParse(Console.ReadLine(), out input);
    
    	if (isNumber)
    	{
    		count++;
    
    		if (count % 5 == 0)
    			total += input;
    	}
    	else
    	{
    		break;
    	}
    
    	Console.Write("Add another number or press enter to get the sum : ");
    }
    
    Console.WriteLine("The sum of every +5 numbers is: {0}", total);
    Console.ReadKey();
