        while (true)
        {
            int user;
            Console.WriteLine("Guess a number boe???");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out user))
            {
                if (user == guess)
                {
                    Console.WriteLine("You a Genius boe!!!");
                    Console.ReadLine();
                    return;
                }
                else if (user == (guess - 1))
                {
                    Console.WriteLine("A bit Higher!");
                }
                else if (user == (guess + 1))
                {
                    Console.WriteLine("A bit Lower!");
                }
                else
                {
                    Console.WriteLine("U Serious Bruh???");
                }
            }
            else
            {
                Console.WriteLine("You didnt entered a correct value try again!!!");
            }
        }
