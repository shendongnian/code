    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    
                string SecretWord = "Banana";
                string Guess = "";
                int GuessCount = 0;
                int GuessLimit = 4;
                bool OutOfGuesses = false;
    
    
                while (Guess != SecretWord && !OutOfGuesses)             
                {
    				Console.Write("Enter a Guess: ");
    				Guess = Console.ReadLine();
    				GuessCount++;
    
    				if (GuessCount >= GuessLimit)
    				{
                        OutOfGuesses = true;
                    }
    
                    if (Guess != SecretWord)
                    {
                        Console.WriteLine("Wrong Guess");
    
                    }
    
                }  
    
                  if (OutOfGuesses)
                {
    
                    Console.WriteLine("You Lose");
    
                }   else {
    
                    Console.WriteLine("You Win!");
    
                }               
    
    
    
    
                Console.ReadLine();
    
            }
    
        }
    }
