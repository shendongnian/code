            string input;
            do
            {
                input = Console.ReadLine();
                if (input.Length != 4)
                    Console.WriteLine("You have to enter FOUR digits");
            } while (input.Length != 4);
