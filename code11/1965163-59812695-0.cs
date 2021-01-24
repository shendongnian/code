            Console.WriteLine("What do you want to do? [1/2]");
            Console.WriteLine("1. Draw");
            Console.WriteLine("2. Stay");
            
            int userChoice = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine();
                Console.WriteLine("Enter choice [1/2]...");
                string input = Console.ReadLine();
                string trimmedInput = input.Trim();
                if (trimmedInput == "1" || trimmedInput == "2")
                {
                    validInput = true;
                    userChoice = Int32.Parse(trimmedInput);
                }
            }
            // We leave the while loop here once validInput == true
            // Now take action based on userChoice
            Console.WriteLine("You chose " + userChoice);
            Console.ReadLine();
