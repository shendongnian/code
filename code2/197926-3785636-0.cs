    static void Main()
    {
    	Restart();
    }
    
    static void Restart()
    {
    	...code
    	
    	string userChoice = Console.ReadLine();
    	if (userChoice=="y")
    		Restart();
    }
