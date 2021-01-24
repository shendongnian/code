            Console.Write("\n\n");
            Console.Write("------------------------------------------------");
            Console.WriteLine("\nThis Program simulates tossing a coin mutliple times");
            Console.Write("------------------------------------------------");
            Console.Write("\n\n");
            int Heads = 0, Tails = 0;
            int compChoice = 0;
            int attempts;
            Random rnd = new Random();
            Console.WriteLine("How many coin tosses?");
            int coinTossChoice = int.Parse(Console.ReadLine());
            //attempts is the counter for each toss
            attempts = 1;
            
            do
            {
                //compChoice is the coin toss containing 0 or 1 at random
                compChoice = rnd.Next(0, 2);
                if (compChoice == 0)
                {
                    Console.WriteLine("Toss Number# " + attempts);
                    Console.WriteLine("\nHeads");
                    Heads++;
                }
                else if (compChoice == 1)
                {
                    Console.WriteLine("Toss Number# " + attempts);
                    Console.WriteLine("\nTails");
                    Tails++;
                }
            //increment attempt
            attempts++;
            //cycle as many times as the user requested
            } while (attempts <= coinTossChoice);
            Console.WriteLine("\nNumber of Heads {0} Number of Tails {1} .", Heads, Tails);
            Console.ReadKey();
