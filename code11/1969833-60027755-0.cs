        using System;
        
        namespace BlackJack
        {
            class Program
            {
                static void Main(string[] args)
                {
                Console.WriteLine("First player's turn");
    
                int number = 0;
                Random random = new Random();
                bool continuePlaying = true;
    
                do
                {
                    Console.WriteLine("Are you downloading the card? [Y]es/[N]o");
                    string userAnswer = Console.ReadLine();
    
                    switch (userAnswer.ToLower())
                    {
                        case "y":
                            int randomNumber = random.Next(1, 10);
                            number += randomNumber;
    
                            Console.WriteLine($"Your total of points is: {number}");
                            continuePlaying = true;
                            break;
    
                        case "n":
                            Console.WriteLine($"Your total of points is: {number}");
                            continuePlaying = false; // Stop playing
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please choose [Y]es or [N]o");
                            continuePlaying = true;
                            break;
                    }
                } while (number < 22 && continuePlaying == true);
                
                if (number <= 21)
                {
                    Console.WriteLine($"You end the game with a total of {number} points");
                }
                else
                {
                    Console.WriteLine($"The player 1 lost with {number} points");
                }
                Console.ReadLine();
            }
        }
    }
