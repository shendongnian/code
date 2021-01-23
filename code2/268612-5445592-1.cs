        double total = 0;
        int myint = -1;
        while (myint != 0)
        {
            string group;
            
            Console.WriteLine("Please enter group number (4, 5, or 6)");
            Console.WriteLine("(0 to quit): ");
            group = Console.ReadLine();
            myint = Int32.Parse(group);
            switch (myint)
            {
                case 0:
                    Console.WriteLine("Bye.");
                    break;
                case 4:
                case 5:
                case 6:
                    double donation;
                    string inputString;
                    Console.WriteLine("Please enter the amount of the contribution: ");
                    inputString = Console.ReadLine();
                    donation = Convert.ToDouble(inputString);
                    total += donation;
                    break;
                default:
                    Console.WriteLine("Incorrect grade number.", myint);
                    break;
            }
        }
        Console.WriteLine("Your total is {0}", total.ToString("C"));
