using System;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num1");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num2");
            int num2 = int.Parse(Console.ReadLine());
            bool GameOver = false;
            int turn = 3;
            Random random = new Random();
            int answer = random.Next(num1, num2);
            // string input = "";
            Console.WriteLine("Hello, welcome to the guess a number challenge");
            while (!GameOver)
            {
                if (turn != 0)
                {
                    turn--;
                    Console.WriteLine($"Please Select number between {num1} to {num2}:");
                    int SelectedNumber = int.Parse(Console.ReadLine());
                    if (SelectedNumber < answer && SelectedNumber >= num1)
                    {
                        System.Console.WriteLine("Almost there, just the number is too small\n");
                    }
                    else if (SelectedNumber > answer && SelectedNumber <= num2)
                    {
                        System.Console.WriteLine("Your number is too big\n");
                    }
                    else if (SelectedNumber == answer)
                    {
                        System.Console.WriteLine("CONGRATULATIONS!!!! You guess it right\n");
                        GameOver = true;
                        retry();
                    }
                    else
                    {
                        System.Console.WriteLine("Your number is out of range\n");
                    }
                }
                else
                {
                    System.Console.WriteLine($"GAME OVER!!!! The answer is {answer}");
                    GameOver = true;
                    retry();
                }
                void retry()
                {
                    System.Console.WriteLine("Would you like to retry? Y/N");
                    string input = Console.ReadLine();
                    string ConsoleInput = input.ToLower();
                    if (ConsoleInput == "y")
                    {
                        answer = random.Next(num1, num2);
                        GameOver = false;
                        turn = 3;
                    }
                    else if (ConsoleInput == "n")
                    {
                        GameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        retry();
                    }
                }
            }
        }
    }
}
