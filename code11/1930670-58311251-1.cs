        static void Main(string[] args)
        {
            Random random = new Random();
            int guessNum = random.Next(1, 21);
            
            while(true)
            {
                Console.WriteLine("Guess the number between 1 and 21.");
                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == guessNum)
                    {
                        Console.WriteLine($"You guessed it right. The number is {input}");
                        if(ShouldContinue())
                        {
                            guessNum = random.Next();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (input < guessNum)
                        Console.WriteLine("The number you guessed is smaller.");
                    else
                        Console.WriteLine("The number you guessed is bigger");
                        
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 21 as your guess");
                }
            }
        }
        static bool ShouldContinue()
        {
            while (true)
            {
                Console.WriteLine($"Do you want to continue playing? (y/n)");
                string continueInput = Console.ReadLine().Trim().ToLower();
                if (continueInput == "y")
                    return true;
                else if (continueInput == "n")
                    return false;
                else
                    Console.WriteLine("Invalid input!. Please choose 'y' or 'n'.");
            }
        }
Old answer:
while (true)
{
    if (Int32.TryParse(inputInt, out int myNum))
    {
       // your logic goes here, too low/high or correct answer.   
    }
}
