            while (true)
            {
                Console.Write("Enter the first number or type \"quit\" to exit: ");
                String entry = Console.ReadLine();
                if (entry.ToLower() == "quit")
                {
                    break;
                }
                x = Convert.ToInt32(entry);
                // Prompt the user for an operation (+ - / *).
                Console.Write("Enter an operation ");
                operation = Convert.ToChar(Console.ReadLine());
                // Prompt user for next number
                Console.Write("Enter the next number ");
                y = Convert.ToInt32(Console.ReadLine());
