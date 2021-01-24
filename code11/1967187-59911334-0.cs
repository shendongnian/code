            int number = 5;
            
            while (true)
            {
                Console.WriteLine("Guess a number boe???");
                int user = Convert.ToInt32(Console.ReadLine());
                if (user == number)
                {
                    Console.WriteLine("You a Genius boe!!!");
                    Console.ReadLine();
                    return;
                }
                else if (user == (number - 1))
                {
                    Console.WriteLine("A bit Higher!");
                }
                else if (user == (number + 1))
                {
                    Console.WriteLine("A bit Lower!");
                }
                else
                {
                    Console.WriteLine("U Serious Bruh???");
                }
            }
