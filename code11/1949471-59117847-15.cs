    using System;
    namespace Guess_Number_V2
    {
        class Program
        {
            static void Main(string[] args)
            {
                do {
                    PlayGame();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Would you play to play again? Y or N");
                } while (Console.ReadLine().ToLower() == "y");
            }
            private static void PlayGame()
            {
                Random rand = new Random();
                int randNum = rand.Next(1, 11);
                int incorrectGuesses = 0;
                int userScore = 10;
                int userGuess;
                int perGuess = 1;
                Console.WriteLine("Enter a number between 1 and 10\nScore starts at 10, one point will be deducted with each incorrect guess.");
                while (true) {
                    userGuess = int.Parse(Console.ReadLine());
                    if (userGuess == randNum) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your guess was right, the number was {0}! Total score is {1} and you had {2} incorrect guesses.", randNum, userScore, incorrectGuesses);
                        break;
                    }
                    userScore -= perGuess;
                    incorrectGuesses++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (userGuess > randNum) {
                        Console.WriteLine("Wrong guess again, to high!");
                    } else { // Must be userGuess < randNum
                        Console.WriteLine("Wrong guess again, to low!");
                    }
                }
            }
        }
    }
