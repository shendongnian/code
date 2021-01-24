            while (true)
            {
                Console.Write("Enter a number or type \"quit\" to exit: ");
                String entry = Console.ReadLine();
                if (entry.ToLower() == "quit")
                {
                    break;
                }
                // Prompt user for the first number
                Console.Write("Enter the first number:  ");
                x = Convert.ToInt32(Console.ReadLine());
                // Prompt the user for an operation (+ - / *).
                Console.Write("Enter an operation ");
                operation = Convert.ToChar(Console.ReadLine());
                // Prompt user for next number
                Console.Write("Enter the next number ");
                y = Convert.ToInt32(Console.ReadLine());
