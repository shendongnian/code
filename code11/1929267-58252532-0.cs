       TinasDice();
    
            Console.WriteLine("Do you want to play again?");
            string answer = "YES";
            int counter = 0;
           
    
            while (answer == "YES")
            {
                answer = Console.ReadLine();
                counter++;
                if (answer == "YES")
                {
                    TinasDice();
                }
                else
                {
                    Console.WriteLine("The number of times the dice was die was thrown is: " + counter);
                    Console.WriteLine("Nice game!");
                    Console.WriteLine("Thanks for playing. Come play again soon!");
                    break;
                }
    
            }
        }
