    class Program
    {
        public static int RandomNumberGenerator()
        {
            Random random = new Random();
            
            var generatedNumber = random.Next(1, 21);
            Console.WriteLine($"New Number generated! {generatedNumber}");
            return generatedNumber;
        }
        public static int InputGetter()
        {
            Console.Write("Enter in a number: ");
            int guess = Convert.ToInt32(Console.ReadLine());
            return guess;
        }
        public static String GuessChecker(int guess, int secretNumber)
        {
            if (guess > secretNumber)
            {
                Console.WriteLine("Too High");
                return "Too high!";
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Too low!");
                return "Too low!";
            }
            else
            {
                Console.WriteLine("Correct");
                return "Correct";
            }
        }
        static void Main(string[] args)
        {
            int secretNumber = 10;
            Console.WriteLine("" + secretNumber);
            while (true)
            {
                int enteredNumber = 0;
                do
                {
                    enteredNumber = InputGetter();
                } while (GuessChecker(enteredNumber, secretNumber)!="Correct");
                Console.WriteLine("Would you like to play again?[Yes/No]");
                String input = Console.ReadLine();
                if (input=="Yes")
                {
                    secretNumber = RandomNumberGenerator();
                }
                else 
                {
                    break;
                }
               
            }
        }
    }
