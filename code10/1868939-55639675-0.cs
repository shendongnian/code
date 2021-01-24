    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Random rnd = new Random(); // create Random object
    		
    		Console.WriteLine("Enter a number between  1 and 6: "); // prompt user to enter a number between 1 and 6
                
    		int chosenNumberInt;
    		var chosenNumber = int.TryParse(Console.ReadLine(), out chosenNumberInt); // check to see if user actually entered a number.  If so, put that number into the chosenNumberInt variable
    
    		Console.WriteLine("Chosen Number = " + chosenNumberInt); // show user what they entered
    		Console.WriteLine("------------");
    
    		int count = 0;
    		int numberRolled = 0;
    		while (numberRolled != chosenNumberInt)
    		{
    			count++;
    			int dice = rnd.Next(1, 7);
    			numberRolled = dice;
    
    			Console.WriteLine(numberRolled); // show each roll
    		}
    		
    		Console.WriteLine("-------------");
    		Console.WriteLine("The chosen number was " + numberRolled + " and the number of rolls it took to hit that number was " + count);
    	}
    }
