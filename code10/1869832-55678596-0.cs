	using System;
    public class diceCounter
    {
        public static void Main(string[] args)
        {
			String UserInput;
			int Counter =1;
            Console.WriteLine("Hey! Welcome to Ray's Dice Game! Let's Start");
            Console.WriteLine();
			do
			{
				EvenOrOdds();
				Console.WriteLine("Do you want to play again? Please enter in all caps YES or NO");
				UserInput = Console.ReadLine();
				if (UserInput.Equals("YES"))
				{
					Counter++;
					EvenOrOdds();
				}
			}while(!(UserInput.Equals("NO")));
				
			Console.WriteLine("The number of times the dice was thrown is: " + Counter);
			Outro();
        }
        public static void EvenOrOdds()
        {
            Random rnd = new Random();
            int die1 = rnd.Next(1, 10);
            int die2 = rnd.Next(1, 10);
            Console.WriteLine("Die 1 = {0} and Die 2 = {1}", die1, die2);
            Console.WriteLine();
            Console.WriteLine("You Rolled {0} and {1}", die1, die2);
            Console.WriteLine();
            if ((die1 + die2) % 2 == 0)
            {
                Console.WriteLine("Evens are better than odd.");
                Console.WriteLine();
            }
            if ((die1 + die2) % 2 > 0 )
            {
                Console.WriteLine("Odds are still cool.");
                Console.WriteLine();
            }
        }
        public static void Outro()
        { 
			Console.WriteLine("\nThanks for playing! Come again!\n");
        }
    }
