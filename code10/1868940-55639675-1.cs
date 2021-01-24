    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Random rnd = new Random(); // create Random object
    		
    		Console.WriteLine("Enter a number between  1 and 6: "); // prompt user to enter a number between 1 and 6
    		int chosenNumberInt;
    		var chosenNumber = int.TryParse(Console.ReadLine(), out chosenNumberInt); // check to see if user actually entered a number.  If so, put that number into the chosenNumberInt variable
    		
    		
    		Console.WriteLine("How many rolls would you like?"); // prompt user to enter how many rolls they would like to have
    		int chosenRollsInt;
    		var chosenRolls = int.TryParse(Console.ReadLine(), out chosenRollsInt);
    		
    		Console.WriteLine(); // to create space
    		Console.WriteLine(); // to create space
                
    		Console.WriteLine("Chosen Number = " + chosenNumberInt + " --- Chosen Rolls = " + chosenRollsInt); // show user what they entered
    		Console.WriteLine("------------");
    
    		int count = 0;
    		int numberRolled = 0;
    		var lstRolls = new List<int>(); // create list object
    		
    		for(int i = 1; i <= chosenRollsInt; i++)
    		{
    			count++;
    			int dice = rnd.Next(1, 7);
    			numberRolled = dice;
    			
    			lstRolls.Add(numberRolled); // add each roll to the list
    			
    			Console.WriteLine("Roll " + i + " = " + numberRolled); // show each roll
    		}
    		
    		var attempts = lstRolls.Count; // how many rolls did you do
    		var firstIndexOfChosenNumber = lstRolls.FindIndex(x => x == chosenNumberInt) + 1; // have to add 1 because finding the index is 0-based
    		Console.WriteLine("-------------");
    		
    		if(firstIndexOfChosenNumber == 0)
    			Console.WriteLine("The chosen number was " + chosenNumberInt + " and that number was NEVER rolled with " + chosenRollsInt + " rolls.");
    		else
    			Console.WriteLine("The chosen number was " + chosenNumberInt + " and the number of rolls it took to hit that number was " + firstIndexOfChosenNumber);
    	}
    }
