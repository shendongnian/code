    static void Main(string[] args)
    {
    	var meny = true;
    	var items = new List<string>();
    	string newInventoryItem = "";
    	while (meny)
    	{
    		Console.WriteLine(" \tWelcome to the inventory");
    
    		Console.WriteLine("\t[1] Add item");
    		Console.WriteLine("\t[2] Show your inventory");
    		Console.WriteLine("\t[3] Delete your inventory");
    		Console.WriteLine("\t[4] Quit");
    		Console.Write("\tChoose: ");
    
    		int menyVal = Convert.ToInt32(Console.ReadLine());
    
    
    		// switch 
    		switch (menyVal)
    		{
    			case 1:
    				Console.WriteLine("\nAdd item: ");
    				
    				// Read the new item from the console
    				newInventoryItem = Console.ReadLine();
    				
    				// Add it to our list of inventory items.
    				items.Add(newInventoryItem);
    				
    				break;
    			case 2:
    			
    				//take our items, and put together a string
    				// where each item is on a new line
    				var itemStr = string.Join("\r\n", items);
    				
    				Console.WriteLine(itemStr);
    
    				break;
    			case 3:
    				Console.WriteLine("\n\tRemoving items ");
    				
    				// Remove everything from the list
    				items.Clear();
    				break;
    				
    			case 4:
    				meny = false;
    				break;
    				
    			default:
    				Console.WriteLine("\nError, Not a valid value, Try again");
    				break;
    }
