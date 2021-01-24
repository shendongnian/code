    public static void Main()
    {
    	List<string> names = new List<string>() { "Vasti", "Cameron", "Ezra", "Tilly" };
    
    	string userChoice = "";
    	do
    	{
    		Console.WriteLine($@"Welcome to the names lost!{Environment.NewLine} If you wish to add a name to the list, type 1.{Environment.NewLine} If you want to see current names in the list, type 2.");
    		userChoice = Console.ReadLine();
    
    		switch (userChoice)
    		{
    			case "1":
    				Console.WriteLine("Add a name to the squad.");
    				string userAddName = Console.ReadLine();
    				names.Add(userAddName);
    				break;
    			case "2":
    				Console.WriteLine("Here's the list:");
    				foreach (string name in names)
    				{
    					Console.WriteLine(name);
    				}
    
    				break;
    			default:
    				Console.WriteLine("Please type either 1 or 2 to select an option.");
    				break;
    		}
    		Console.WriteLine(@"Wanna do that again? Type yes or no.");
    		userChoice = Console.ReadLine();
    	}
    	while (userChoice.Equals("yes", StringComparison.OrdinalIgnoreCase));
    
    	Console.WriteLine("Program finished");
    	Console.ReadLine();
    }
