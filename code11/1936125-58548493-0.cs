    using System;
    					
    public class Program
    {
    	public static void Main()
        {
        	string userInput;
    		double diameter;
        	Console.Write("\nPlease enter the diameter of your pizza: ");
        	userInput = Console.ReadLine();
            
    		while(true)
            {
    			var isDouble = double.TryParse(userInput, out diameter) == true;
    
                if (!isDouble)
                {
                    Console.WriteLine("\nENTRY NON-NUMBERIC ERROR\n");
                    Console.WriteLine("Pizza must have a numeric diameter. You entered: \"{0}\"\n", userInput);
                    Console.WriteLine("Please try again.\n");
    				diameter = 0;
                    //**if userInput isn't valid, diameter becomes 0**
                }
                else
                {
    				if (diameter == 0)
    				{
    					Console.Write("\n Exit initiated");
    					break;
    				}
                }
    			
                Console.Write("\nPlease enter the diameter of your pizza (0 to end program): ");
                userInput = Console.ReadLine();
                double.TryParse(userInput, out diameter);
                Console.Clear();
    		}
    	}
    }
